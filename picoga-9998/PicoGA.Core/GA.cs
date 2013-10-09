/* A super-tiny GA implementation, by Mattias.Fagerlund@cortego.se. http://lotsacode.wordpress.com/ 
 It could be made waay shorter, but that would mean giving up what little readability there is...*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PicoGA
{
    public class GA
    {
        private Func<Individual, double> _fitnessFunction;
        private List<Individual> _population = new List<Individual>();
        private int _genomeSize;
        private int _populationSize;

        static GA()
        { 
            TournamentSize = 7; // count
            Elitism = 50 / 100.0; // %
            GenerationMutants = 5 / 100.0; // %
            PointMutations = 25 / 100.0; // %
            MutationMultiplicationRange = 0.025;
            MutationAdditionRange = 0.1;
            ChildMutationRate = 80 / 100.0; // %
            InitialWeightRange = 1;
            UseMultiThreading = true;
        }

        public static int TournamentSize { get; set; }
        public static double Elitism { get; set; }
        public static double GenerationMutants  { get; set; }
        public static double PointMutations { get; set; }
        public static double MutationMultiplicationRange { get; set; }
        public static double MutationAdditionRange  { get; set; }
        public static double ChildMutationRate  { get; set; }
        public static int InitialWeightRange { get; set; }
        public static bool UseMultiThreading {get;set;}
        public Action<Individual> InitializeIndividual { get; set; }

        public GA(int populationSize, int genomeSize, Func<Individual, double> fitnessFunction, Action<Individual> initializeIndividual=null)
        {
            _populationSize = populationSize;
            _genomeSize = genomeSize;
            _fitnessFunction = fitnessFunction;
            InitializeIndividual = initializeIndividual;
            CurrentEpochGeneration = -1;
        }

        public Individual BestIndividual { get { return _population.First(); } }
        public int CurrentEpochGeneration { get; private set; }

        public void RunEpoch(int generationsToRun, Action everyGenerationAction, Action fitessChangeAction)
        {
            BreakEpochRun = false;
            double previousBest = 0;
            for (int generationNr = 0; generationNr < generationsToRun; generationNr++)
            {
                CurrentEpochGeneration = generationNr;
                RunGeneration();
                if (Math.Abs(previousBest - BestIndividual.Fitness) > 0.001)
                {
                    if (fitessChangeAction != null)
                    {
                        fitessChangeAction();
                    }
                }

                if (everyGenerationAction != null)
                {
                    everyGenerationAction();
                }

                previousBest = BestIndividual.Fitness;

                if (BreakEpochRun)
                {
                    break;
                }
            }
        }

        public bool BreakEpochRun { get; set; }

        public void RunGeneration()
        {
            CreateNewGeneration();
        }

        private void CreateNewGeneration()
        {
            if (_population.Any() == false)
            {
                CreateRandomPopulation();
            }
            else
            {
                EvolveNewGeneration();
            }
            ComputePopulationFitness();
        }

        private void CreateRandomPopulation()
        {
            _population.Clear();
            // FillList is an extension method
            _population.FillList(_populationSize, () => new Individual(_genomeSize));

            if(InitializeIndividual!=null)
            {
                _population.ForEach(InitializeIndividual);
            }
        }

        private void EvolveNewGeneration()
        {
            List<Individual> newPopulation = new List<Individual>();

            // Elitist selection - we pick the previous winner, that way fitness never goes backwards
            newPopulation.Add(BestIndividual.Clone());

            // Mutate a few of the top contenders
            newPopulation.FillList((int)((_populationSize * GenerationMutants)), () => TournamentSelection(TournamentSize).Clone().Mutate());

            // Use crossover for the rest!
            newPopulation.FillList(
                _populationSize,
                () => TournamentSelection(TournamentSize).Clone().UniformCrossover(TournamentSelection(TournamentSize)));

            _population = newPopulation;
        }

        private Individual TournamentSelection(int tournamentSize)
        {
            List<Individual> tournament = new List<Individual>();
            // Only the top X% are allowed in the tournament
            tournament.FillList(
                tournamentSize,
                () => _population[Helper.Random.Next((int)((_populationSize * Elitism)))]);
            return tournament.Lowest(individual => individual.Fitness);
        }

        private void ComputePopulationFitness()
        {
            if (UseMultiThreading)
            {
                Parallel.ForEach(_population, individual => individual.Fitness = _fitnessFunction(individual));
            }
            else
            {
                _population.ForEach(individual => individual.Fitness = _fitnessFunction(individual));
            }
            _population = _population.OrderBy(individual => individual.Fitness).ToList();
        }
    }

    public class Individual
    {
        private List<double> _genotype = new List<double>();
        public Individual(int genomeSize)
        {
            // FillList is an extension method
            _genotype.FillList(genomeSize, () => Helper.NextDouble(-GA.InitialWeightRange, GA.InitialWeightRange));
        }
        // Lower fitness is better!
        public double Fitness { get; set; }
        public List<double> Genotype { get { return _genotype; } }

        public Individual Clone()
        {
            Individual clone = new Individual(0);
            clone.Genotype.AddRange(_genotype);
            return clone;
        }

        public Individual Mutate()
        {
            int loopCount = (int)(Math.Ceiling(_genotype.Count * GA.PointMutations));
            Helper.Loop(loopCount,
                () =>
                {
                    int pos = Helper.Random.Next(_genotype.Count);
                    _genotype[pos] =
                        _genotype[pos] * Helper.NextDouble(1 - GA.MutationMultiplicationRange, 1 + GA.MutationMultiplicationRange) +
                        Helper.NextDouble(-GA.MutationAdditionRange, GA.MutationAdditionRange);
                });

            return this;
        }

        public Individual UniformCrossover(Individual other)
        {
            Helper.Loop(_genotype.Count,
                index =>
                {
                    if (Helper.Random.Next(2) == 0)
                    {
                        _genotype[index] = other.Genotype[index];
                    }
                });

            if (Helper.Random.NextDouble() <= GA.ChildMutationRate)
            {
                Mutate();
            }

            return this;
        }
    }

    public static class Helper
    {
        internal static Random _random = new Random();

        public static Random Random { get { return _random; } }

        public static double NextDouble(double min, double max)
        {
            return Random.NextDouble() * (max - min) + min;
        }

        public static void Loop(int count, Action action)
        {
            for (int i = 0; i < count; i++)
            {
                action();
            }
        }

        public static void Loop(int count, Action<int> action)
        {
            for (int i = 0; i < count; i++)
            {
                action(i);
            }
        }

        public static void FillList<TType>(this ICollection<TType> enumerable, int count, Func<TType> func)
        {
            while (enumerable.Count < count)
            {
                enumerable.Add(func());
            }
        }

        public static TType Lowest<TType>(this ICollection<TType> enumerable, Func<TType, double> func)
        {
            TType bestSoFar = enumerable.First();
            double lowest = func(bestSoFar);
            foreach (TType test in enumerable)
            {
                double testValue = func(test);
                if (testValue <= lowest)
                {
                    if (testValue == lowest && Random.Next(10) < 5)
                    {
                        continue;
                    }

                    bestSoFar = test;
                    lowest = testValue;
                }
            }

            return bestSoFar;
        }
    }
}

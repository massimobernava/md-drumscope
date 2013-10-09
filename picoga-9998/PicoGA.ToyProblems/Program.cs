using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PicoGA.ToyProblems
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("PicoGA, ToyProblems");
            SumTo50();
            Find12345();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        private static void SumTo50()
        {
            Console.WriteLine("Sum to 50:...");
            GA ga = new GA(
                20, // Number of individuals
                3, // Number of genes in the genotype
                individual => // Fitness function
                    Math.Abs(50 - individual.Genotype.Sum(val => val))
                );

            ga.RunEpoch(
                500, // Number of generations to run for
                null, // Action to perform for each generation
                () => // Action to perform once fitness has improved
                {
                    Console.WriteLine(
                        "Gen {2}: Fit={1}, Genotype={0}",
                        string.Join(
                            " ",
                            ga.BestIndividual.Genotype.Select(val => val.ToString("0.00"))),
                        ga.BestIndividual.Fitness.ToString("0.00"),
                        ga.CurrentEpochGeneration);
                });

            Console.WriteLine("Sum to 5: done!");
            Console.WriteLine("");
        }

        private static void Find12345()
        {
            Console.WriteLine("Find 1 2 3 4 5:...");
            GA ga = new GA(
                200, // Number of individuals
                5, // Number of genes in the genotype
                individual => // Fitness function
                Math.Abs(individual.Genotype[0] - 1) +
                Math.Abs(individual.Genotype[1] - 2) +
                Math.Abs(individual.Genotype[2] - 3) +
                Math.Abs(individual.Genotype[3] - 4) +
                Math.Abs(individual.Genotype[4] - 5));

            ga.RunEpoch(500, null, () =>
                {
                    Console.WriteLine(
                        "Gen {2}: Fit={1}, Genotype={0}",
                        string.Join(
                        " ",
                        ga.BestIndividual.Genotype.Select(
                            val => val.ToString("0.00"))),
                        ga.BestIndividual.Fitness.ToString("0.00"),
                        ga.CurrentEpochGeneration);
                });

            Console.WriteLine("Find 1 2 3 4 5: done!");
            Console.WriteLine("");
        }        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Media3D;

namespace PicoGA.FindMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Find ProjectionMatrix:...");
            FindProjectionMatrix();
            Console.WriteLine("Done!");
            Console.ReadKey();
        }

        internal class WorldToScreenCase
        {
            public WorldToScreenCase(double screenX, double screenY, double worldX, double worldY)
            {
                Screen = new Point3D(screenX, screenY, 0);
                World = new Point3D(worldX, worldY, 0);
            }

            internal Point3D Screen { get; set; }
            internal Point3D World { get; set; }
        }

        public static void FindProjectionMatrix()
        {
            List<WorldToScreenCase> cases =
                new List<WorldToScreenCase>
                {						
                    // New image
                    /*new WorldToScreenCase(690, 350,       0,      0),
					new WorldToScreenCase(455, 155, 105*0.5,      0),
					new WorldToScreenCase(353,  70,     105,      0),
					new WorldToScreenCase(128, 169, 105*0.5, 68*0.5),
					new WorldToScreenCase(153, 412,       0, 68*0.5),*/


                    // Old Image
                    new WorldToScreenCase(165,178 ,       0,      0),
                    new WorldToScreenCase(377,120 ,       52.5,      0),
                    new WorldToScreenCase(513,85 ,       105,      0),
                    new WorldToScreenCase(473,157 ,       52.5,      34),
                    new WorldToScreenCase(611,208 ,       52.5,      68),
                    new WorldToScreenCase(735,136 ,       105,      68),
                };

            GA ga = new GA(
                2000, // Number of individuals
                16, // Number of genes in the genotype
                individual => // Fitness function
                {
                    double errorSum = 0;
                    foreach (WorldToScreenCase test in cases)
                    {
                        Point3D testScreen = ProjectCase(test.World, individual.Genotype);
                        double sqrError = (testScreen - test.Screen).LengthSquared;
                        errorSum += sqrError;
                    }

                    return errorSum;
                });

            ga.RunEpoch(10000,
                () =>
                {
                    ga.BreakEpochRun = ga.BestIndividual.Fitness <= 1.0 || Console.KeyAvailable;
                },
                () =>
                {
                    Console.WriteLine(
                        "Gen {2}: Fit={1}, Genotype={0}",
                        string.Join(
                        " ",
                        ga.BestIndividual.Genotype.Take(5).Select(
                            val => val.ToString("0.00"))),
                        ga.BestIndividual.Fitness.ToString("0.00"),
                        ga.CurrentEpochGeneration);
                });

            if (Console.KeyAvailable)
            {
                Console.ReadKey();
            }

            Console.WriteLine("Results for training set:");
            foreach (WorldToScreenCase test in cases)
            {
                ShowTestResult(ga, test);
            }

            Console.WriteLine("");
            Console.WriteLine("Additional tests:");
            ShowTestResult(ga, new WorldToScreenCase(120, 73, 105, 34));

            Console.WriteLine("Find ProjectionMatrix: done!");
            Console.WriteLine("");
        }

        private static void ShowTestResult(GA ga, WorldToScreenCase test)
        {
            Point3D p = ProjectCase(test.World, ga.BestIndividual.Genotype);
            Console.WriteLine(
                " World ({0:0.00}, {1:0.00}) => \n" +
                "   Wanted:({2:0.00}, {3:0.00}) \n" +
                "   Received:({4:0.00}, {5:0.00})",
                test.World.X,
                test.World.Y,
                test.Screen.X,
                test.Screen.Y,
                p.X,
                p.Y);
        }

        private static Point3D ProjectCase(Point3D point, List<double> l)
        {
            Point3D p = new Point3D(
                point.X - l[12] * 100,
                point.Y - l[13] * 100,
                point.Z - l[14] * 100);

            Point3D result = new Point3D(
                l[0] * p.X + l[1] * p.Y + l[2] * p.Z + l[3],
                l[4] * p.X + l[5] * p.Y + l[6] * p.Z + l[7],
                l[8] * p.X + l[9] * p.Y + l[10] * p.Z + l[11]);

            if (result.Z != 0)
            {
                result.X *= l[15] / result.Z;
                result.Y *= l[15] / result.Z;
            }

            return result;
        }
    }
}

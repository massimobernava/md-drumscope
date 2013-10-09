using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Media3D;

namespace PicoGA.FindMatrixGui
{
    public partial class MainForm : Form
    {
        private Bitmap _pitch;

        private const string PitchFileName = "new-pitch-with numbers.png";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _pitch = new Bitmap(PitchFileName);
            pitchPictureBox.Image = _pitch;
        }

        internal class WorldToScreenCase
        {
            public WorldToScreenCase(double screenX, double screenY, double worldX, double worldY, double worldZ)
            {
                Screen = new Point3D(screenX, screenY, 0);
                World = new Point3D(worldX, worldY, worldZ);
            }

            internal Point3D Screen { get; set; }
            internal Point3D World { get; set; }
        }

        public void FindProjectionMatrix()
        {
            List<WorldToScreenCase> cases =
                new List<WorldToScreenCase>
                {						
                    new WorldToScreenCase(688, 349, 0,0 ,0), // 1
                    new WorldToScreenCase(454, 155, 52.5,0,0), // 2
                    new WorldToScreenCase(353, 70,  105,0,0), // 3
                    new WorldToScreenCase(127, 169, 52.5, 34,0), // 4
                    new WorldToScreenCase(155, 411, 0, 34,0), // 5
                    new WorldToScreenCase(220, 364, 0, 34 - 7.32*0.5, 2.44), // 6
                    new WorldToScreenCase(80,  378, 0, 34+7.32*0.5,2.44), // 7
                    new WorldToScreenCase(92,  57,  105, 34 + 7.32*0.5, 2.44), // 8
                    new WorldToScreenCase(145, 56,  105, 34-7.32*0.5,2.44), // 9
                };

            GA ga = new GA(
                5000, // Number of individuals
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

            ga.RunEpoch(100000,
                () =>
                {
                    ga.BreakEpochRun = ga.BestIndividual.Fitness <= 1.0 || stopButton.Enabled == false;
                    Application.DoEvents();
                },
                () =>
                {
                    generationLabel.Text = string.Format(
                        "Gen {2}: Fit={1}, Genotype={0}",
                        string.Join(
                        " ",
                        ga.BestIndividual.Genotype.Select(val => val.ToString("0.00"))),
                        ga.BestIndividual.Fitness.ToString("0.00"),
                        ga.CurrentEpochGeneration);
                    DrawCasesToBitmap(cases, ga.BestIndividual.Genotype);
                });
        }

        private void DrawCasesToBitmap(List<WorldToScreenCase> cases, List<double> matrix)
        {
            Bitmap copy = new Bitmap(_pitch);
            Graphics graph = Graphics.FromImage(copy);

            SolidBrush redBrush = new SolidBrush(Color.Red);
            SolidBrush blueBrush = new SolidBrush(Color.Blue);
            Pen pen = new Pen(Color.Red);
            float r1 = 5;
            float r2 = 3;
            cases.ForEach(test =>
                {
                    graph.FillEllipse(blueBrush, (float)(test.Screen.X - r1 / 2), (float)(test.Screen.Y - r1 / 2), r1, r1);

                    Point3D p = ProjectCase(test.World, matrix);
                    graph.FillEllipse(redBrush, (float)(p.X - r2 / 2), (float)(p.Y - r2 / 2), r2, r2);

                    graph.DrawLine(
                        pen,
                        new Point((int)test.Screen.X, (int)test.Screen.Y),
                        new Point((int)p.X, (int)p.Y));
                });

            graph.Dispose();
            pitchPictureBox.Image = copy;
        }

        private void ShowTestResult(GA ga, WorldToScreenCase test)
        {
            Point3D p = ProjectCase(test.World, ga.BestIndividual.Genotype);
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

        private void stopButton_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = false;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            stopButton.Enabled = true;
            FindProjectionMatrix();
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            FindProjectionMatrix();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            stopButton.Enabled = false;
        }
    }
}

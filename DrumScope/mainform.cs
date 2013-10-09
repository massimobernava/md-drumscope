using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using ZedGraph;
using PicoGA;


namespace DrumScope
{
    struct Pair
    {
        public double X;
        public double Y;
        public int Status;
        public int AWindow;
        public double MaxReading;
    }
    public partial class MainForm : Form
    {
        PointPairList list = new PointPairList();
        //List<Pair> PairList = new List<Pair>();
        List<Pair> gPairList = new List<Pair>();

        int WindowsSize = 10000;

        public MainForm()
        {
            InitializeComponent();

            GraphPane panel = zedGraphControl.GraphPane;
            panel.AddCurve("Drum", list, Color.Red, SymbolType.None);


            zedGraphControl.GraphPane.YAxis.Scale.Min = 0;
            zedGraphControl.GraphPane.YAxis.Scale.Max = 1023;

            zedGraphControl.GraphPane.XAxis.Title.Text = "Time (m/s)";
            zedGraphControl.GraphPane.YAxis.Title.Text = "Velocity";
        }
        private void UpdateGraph(List<Pair> PairList)
        {
            if (PairList.Count < hScrollBar.Value) return;

            list.Clear();

            double StartScan = 0;
            double StartMask = 0;
            double StartRetrigger = 0;
            double StartAWin = 0.0;
            double MaxReading = 0;

            zedGraphControl.GraphPane.GraphObjList.Clear();
            for (int i = hScrollBar.Value; i < hScrollBar.Value + WindowsSize; i++)
            {
                list.Add(PairList[i].X, PairList[i].Y);

                if (StartAWin == 0 && PairList[i].AWindow > 0)
                {
                    StartAWin = PairList[i].X;
                }

                if (StartAWin > 0 && (PairList[i].AWindow == 0 || i == hScrollBar.Value + WindowsSize - 1))
                {
                    ZedGraph.BoxObj box = new BoxObj(StartAWin, 50, PairList[i].X - StartAWin, 50.0, Color.Black, Color.FromArgb(64, Color.Black));
                    box.ZOrder = ZOrder.D_BehindAxis;
                    box.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(box);
                    StartAWin = 0;
                }

                if (PairList[i].AWindow == 2)
                {
                    ZedGraph.LineObj line = new LineObj(Color.Green, PairList[i].X, 1023, PairList[i].X, 0);
                    line.ZOrder = ZOrder.D_BehindAxis;
                    line.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(line);
                }

                if (StartScan == 0 && PairList[i].Status == 1)
                {
                    StartScan = PairList[i].X;
                }
                if (StartScan > 0 && PairList[i].Y > MaxReading) MaxReading = PairList[i].Y;
                if (StartScan > 0 && (PairList[i].Status != 1 || i == hScrollBar.Value + WindowsSize - 1))
                {
                    ZedGraph.BoxObj box = new BoxObj(StartScan, /*PairList[i - 1].*/MaxReading, PairList[i].X - StartScan, MaxReading, Color.Black, Color.FromArgb(64, Color.Yellow));
                    box.ZOrder = ZOrder.D_BehindAxis;
                    box.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(box);
                    StartScan = 0;
                    MaxReading = 0;
                }
                if (StartMask == 0 && PairList[i].Status == 2)
                {
                    StartMask = PairList[i].X;
                }

                if (StartMask > 0 && (PairList[i].Status != 2 || i == hScrollBar.Value + WindowsSize - 1))
                {
                    ZedGraph.BoxObj box = new BoxObj(StartMask, 100, PairList[i].X - StartMask, 100.0, Color.Black, Color.FromArgb(64, Color.Red));
                    box.ZOrder = ZOrder.D_BehindAxis;
                    box.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(box);
                    StartMask = 0;
                }

                if (StartRetrigger == 0 && PairList[i].Status == 3)
                {
                    StartRetrigger = PairList[i].X;
                }

                if (StartRetrigger > 0 && (PairList[i].Status != 3 || i == hScrollBar.Value + WindowsSize - 1))
                {
                    ZedGraph.BoxObj box = new BoxObj(StartRetrigger, 100, PairList[i].X - StartRetrigger, 100.0, Color.Black, Color.FromArgb(64, Color.Blue));
                    box.ZOrder = ZOrder.D_BehindAxis;
                    box.IsClippedToChartRect = true;
                    zedGraphControl.GraphPane.GraphObjList.Add(box);
                    StartRetrigger = 0;
                }
            }
            if ((hScrollBar.Value + WindowsSize) < PairList.Count)
            {
                zedGraphControl.GraphPane.XAxis.Scale.Max = PairList[hScrollBar.Value + WindowsSize].X;
                zedGraphControl.GraphPane.XAxis.Scale.Min = PairList[hScrollBar.Value].X;

                zedGraphControl.Invoke(new EventHandler(delegate { zedGraphControl.AxisChange(); zedGraphControl.Refresh(); }));

            }
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
            if (String.IsNullOrEmpty(openFileDialog.FileName)) return;

            double Remove = (double)nudRandRemove.Value / 100.0;
            Random R = new Random();

            gPairList.Clear();
            // zedGraphControl.GraphPane.YAxis.Scale.Min = chkABS.Checked ? 0 : 1023;

            zedGraphControl.GraphPane.Title.Text = openFileDialog.FileName;

            foreach (string v in File.ReadLines(openFileDialog.FileName))
            {
                string[] x = v.Split(' ');

                Pair p;
                p.X = Convert.ToDouble(x[0].Replace('.', ','));
                if (chkABS.Checked)
                {
                    if (Convert.ToDouble(x[1].Replace('.', ',')) > 0)
                        p.Y = Convert.ToDouble(x[1].Replace('.', ','));
                    else
                        continue;
                }
                else
                    p.Y = Convert.ToDouble(x[1].Replace('.', ','));

                p.Y = p.Y * 1023.0 / 50.0;

                p.Status = 0;
                p.MaxReading = 0.0;
                p.AWindow = 0;
                if (R.NextDouble() > Remove)
                    gPairList.Add(p);

            }
            WindowsSize = 10000 - (int)(10000.0 * Remove);

            hScrollBar.Maximum = gPairList.Count - WindowsSize;
            UpdateGraph(gPairList);
        }

        private void Simulate(List<Pair> PairList,double ScanTime, double MaskTime, double Thresold, double Ret, double AWindowTime)
        {
            for (int i = 0; i < PairList.Count; i++)
            {
                Pair p = PairList[i];
                p.AWindow = 0;
                p.MaxReading = 0;
                p.Status = 0;
                PairList[i] = p;
            }

            double TimeSensor = 0;
            //double ScanTime = (double)nudScanTime.Value;
            //double MaskTime = (double)nudMaskTime.Value;
            //double Thresold = (double)nudThresold.Value;
            double Retrigger = 0.0;

            for (int i = 1; i < PairList.Count - 1; i++)
            {

                if (PairList[i].X - TimeSensor < ScanTime)
                {
                    Pair p = PairList[i];
                    p.MaxReading = PairList[i - 1].MaxReading;
                    p.Status = 1;//ScanTime
                    if (p.Y > p.MaxReading) p.MaxReading = p.Y;
                    PairList[i] = p;

                    Retrigger = p.MaxReading / (Ret/*nudRet.Value*/+ 1.0);
                }
                else
                {
                    Pair p = PairList[i];
                    p.Status = 2;//MaskTime
                    if (PairList[i].X - TimeSensor > MaskTime)
                    {
                        if (PairList[i].X - TimeSensor < 2 * MaskTime)
                        {
                            p.Status = 3;//RetriggerTime
                            if (PairList[i].Y > Thresold && PairList[i].Y > Retrigger)// && (PairList[i].Y > PairList[i - 1].Y + Retrigger) && (PairList[i].Y > PairList[i + 1].Y + Retrigger))
                            {
                                TimeSensor = PairList[i].X;
                                p.Status = 1;
                            }
                        }
                        else
                        {
                            p.Status = 0;//NormalTime
                            if (PairList[i].Y > Thresold) { TimeSensor = PairList[i].X; p.Status = 1; }//ScanTime
                        }
                    }

                    PairList[i] = p;
                }
            }

            double AWindowStart = 0.0;
            //double AWindowTime = (double)nudAWin.Value;
            int MaxWindows = 0;
            for (int i = 0; i < PairList.Count; i++)
            {
                if (AWindowStart == 0.0 && PairList[i].Y > 20.0)
                {
                    AWindowStart = PairList[i].X;
                    MaxWindows = i;
                }
                if (AWindowStart > 0)
                {
                    if (PairList[i].Y > PairList[MaxWindows].Y) MaxWindows = i;

                    Pair p = PairList[i];
                    p.AWindow = 1;
                    PairList[i] = p;

                    if (PairList[i].X - AWindowStart > AWindowTime)
                    {
                        p = PairList[MaxWindows];
                        p.AWindow = 2;
                        PairList[MaxWindows] = p;

                        AWindowStart = 0.0;
                    }

                }
            }
            /*
            int v_yn_1 = yn_1[MulSensor];//Solo per risparmiare l'indirizzamento
            if ((Time - TimeSensor[MulSensor]) < ScanTimeSensor[MulSensor])
            {
                State = 1;//ScanTime

                //Peak
                if ((v_yn_1 > (yn_0 + RetriggerSensor[MulSensor]))
                && (v_yn_1 > (yn_2[MulSensor] + RetriggerSensor[MulSensor]))
                && (v_yn_1 > MaxReadingSensor[MulSensor]))
                {
                    MaxReadingSensor[MulSensor] = v_yn_1;

                    if (MaxXtalkGroup[XtalkGroupSensor[MulSensor]] == 255 || MaxReadingSensor[MaxXtalkGroup[XtalkGroupSensor[MulSensor]]] < v_yn_1) //MaxGroup
                        MaxXtalkGroup[XtalkGroupSensor[MulSensor]] = MulSensor;
                }
            }
            else
            {
                State = 2;//MaskTime
                if ((Time - TimeSensor[MulSensor]) > MaskTimeSensor[MulSensor])
                {
                    State = 0;//NormalTime
                    if (yn_0 > ThresoldSensor[MulSensor]) TimeSensor[MulSensor] = Time;
                }
                //MaxReadingSensor[MulSensor] = -1;
            }*/
        }

        private void Analyze(List<Pair> PairList,out int AWCount, out int ScanCount, out int ScanMaxCount)
        {
            AWCount = 0;
            ScanCount = 0;
            ScanMaxCount = 0;

            for (int i = 0; i < PairList.Count - 1; i++)
            {
                int due = i + 1;
                if (PairList[i].AWindow == 2)// && PairList[i + 1].AWindow !=0)
                    AWCount++;
                if (PairList[i].Status != 1 && PairList[due].Status == 1)
                    ScanCount++;
                if (PairList[i].AWindow == 2 && PairList[i].Status == 1) ScanMaxCount++;
            }

            /* lblAWC.Text = "AWCount: " + AWCount.ToString();
             lblScanCount.Text = "ScanCount:" + ScanCount.ToString();
             lblScanMaxCount.Text = "ScanMaxCount:"+ScanMaxCount.ToString();*/
        }
        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            UpdateGraph(gPairList);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Simulate(gPairList,(double)nudScanTime.Value, (double)nudMaskTime.Value, (double)nudThresold.Value, (double)nudRet.Value, (double)nudAWin.Value);
            UpdateGraph(gPairList);
        }

        private void btnAnalyze_Click(object sender, EventArgs e)
        {
            int AWCount = 0;
            int ScanCount = 0;
            int ScanMaxCount = 0;
            Analyze(gPairList,out AWCount, out ScanCount, out ScanMaxCount);

            lblAWC.Text = "AWCount: " + AWCount.ToString();
            lblScanCount.Text = "ScanCount:" + ScanCount.ToString();
            lblScanMaxCount.Text = "ScanMaxCount:" + ScanMaxCount.ToString();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            for (int i = hScrollBar.Value - 1; i > 0; i--)
            {
                if (gPairList[i].AWindow == 0 && gPairList[i + 1].AWindow == 1)
                {
                    hScrollBar.Value = i;
                    break;
                }
            }
            UpdateGraph(gPairList);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            for (int i = hScrollBar.Value + 1; i < gPairList.Count - WindowsSize; i++)
            {
                if (gPairList[i].AWindow == 0 && gPairList[i + 1].AWindow == 1)
                {
                    hScrollBar.Value = i;
                    break;
                }
            }
            UpdateGraph(gPairList);
        }

        private void Optimize()
        {
            SortedList<int, int> Result = new SortedList<int, int>();
            lblScanCount.Text = "ScanCount:---";
            lblScanMaxCount.Text = "ScanMaxCount:---";

            for (nudAWin.Value = 500; nudAWin.Value > 0; nudAWin.Value--)
            {

                Simulate(gPairList,20, 30, 100, 0, (double)nudAWin.Value);

                int AWCount = 0;
                int ScanCount = 0;
                int ScanMaxCount = 0;
                Analyze(gPairList,out AWCount, out ScanCount, out ScanMaxCount);
                //lblAWC.Text = "AWCount: " + AWCount.ToString();

                Result.Add((int)nudAWin.Value, AWCount);
            }

            KeyValuePair<int, int> Best = Result.First(x => (x.Value == Result.Values.Min()));
            nudAWin.Value = Best.Key;
            lblAWC.Text = "AWCount: " + Best.Value.ToString();

            Random rand = new Random();
            GA ga = new GA(500, 3,
            individual =>
            {
                List<Pair> PairList = gPairList.ToList(); ;
                Simulate(PairList,Math.Abs(individual.Genotype[0] * 100),
                    Math.Abs(individual.Genotype[1] * 100),
                    Math.Abs(individual.Genotype[2] * 100),
                    0/* Math.Abs(individual.Genotype[3] * 100)*/,
                    (double)nudAWin.Value);

                int AWCount = 0;
                int ScanCount = 0;
                int ScanMaxCount = 0;
                Analyze(PairList,out AWCount, out ScanCount, out ScanMaxCount);

                return ((Math.Pow(AWCount - ScanMaxCount, 2) / 4) + Math.Pow(AWCount - ScanCount, 2) + Math.Abs(individual.Genotype[2]) * 10 + Math.Abs(individual.Genotype[1]) * 100 + Math.Abs(individual.Genotype[0]) * 100 + (Math.Abs(individual.Genotype[1]) < Math.Abs(individual.Genotype[0]) ? 100 : 0));
            },
            individual =>
            {
                individual.Genotype[0] = 2 * rand.NextDouble();
                individual.Genotype[1] = 2 * rand.NextDouble();
                individual.Genotype[2] = 2 * rand.NextDouble();
            });

            backgroundWorker1.RunWorkerAsync(ga);

            /* nudScanTime.Value=(decimal)Math.Abs(ga.BestIndividual.Genotype[0]*100);
             nudMaskTime.Value = (decimal)Math.Abs(ga.BestIndividual.Genotype[1]*100);
             nudThresold.Value = (decimal)Math.Abs(ga.BestIndividual.Genotype[2]*100);
             nudRet.Value = 0;//(decimal)Math.Abs(ga.BestIndividual.Genotype[3] * 100);
             */

            //double ScanTime = (double);
            //double MaskTime = (double)
            //double Thresold = (double)

        }
        /*private void Optimize2()
        {
            int AWCount = 0;
            int ScanCount = 0;
            int ScanMaxCount = 0;

            SortedList<int, int> Result = new SortedList<int, int>();
            for (nudAWin.Value = 500; nudAWin.Value > 0; nudAWin.Value--)
            {
                Simulate((double)nudScanTime.Value, (double)nudMaskTime.Value, (double)nudThresold.Value, (double)nudRet.Value, (double)nudAWin.Value);

                Analyze(out AWCount, out ScanCount, out ScanMaxCount);

                lblAWC.Text = "AWCount: " + AWCount.ToString();
                lblScanCount.Text = "ScanCount:" + ScanCount.ToString();
                lblScanMaxCount.Text = "ScanMaxCount:" + ScanMaxCount.ToString();

                Result.Add((int)nudAWin.Value, AWCount);
            }
            KeyValuePair<int, int> Best = Result.First(x => (x.Value == Result.Values.Min()));
            nudAWin.Value = Best.Key;

            nudMaskTime.Value = Best.Key;
            Result.Clear();

            for (nudThresold.Value = 100; nudThresold.Value > 20; nudThresold.Value--)
            {
                Simulate((double)nudScanTime.Value, (double)nudMaskTime.Value, (double)nudThresold.Value, (double)nudRet.Value, (double)nudAWin.Value);

                Analyze(out AWCount, out ScanCount, out ScanMaxCount);

                lblAWC.Text = "AWCount: " + AWCount.ToString();
                lblScanCount.Text = "ScanCount:" + ScanCount.ToString();
                lblScanMaxCount.Text = "ScanMaxCount:" + ScanMaxCount.ToString();

                Result.Add((int)nudThresold.Value, ScanCount);
            }
            Best = Result.First(x => (x.Value == Result.Values.Min()));
            nudThresold.Value = Best.Key;

            Result.Clear();

            for (nudScanTime.Value = 100; nudScanTime.Value > 0; nudScanTime.Value--)
            {
                Simulate((double)nudScanTime.Value, (double)nudMaskTime.Value, (double)nudThresold.Value, (double)nudRet.Value, (double)nudAWin.Value);


                Analyze(out AWCount, out ScanCount, out ScanMaxCount);

                lblAWC.Text = "AWCount: " + AWCount.ToString();
                lblScanCount.Text = "ScanCount:" + ScanCount.ToString();
                lblScanMaxCount.Text = "ScanMaxCount:" + ScanMaxCount.ToString();

                Result.Add((int)nudScanTime.Value, ScanMaxCount);
            }
            Best = Result.First(x => (x.Value > ScanCount * 0.9));
            nudScanTime.Value = Best.Key;

            nudRet.Value = 0;
            Result.Clear();
            for (nudMaskTime.Value = nudMaskTime.Value / 2; nudMaskTime.Value > 0; nudMaskTime.Value--)
            {
                Simulate((double)nudScanTime.Value, (double)nudMaskTime.Value, (double)nudThresold.Value, (double)nudRet.Value, (double)nudAWin.Value);

                Analyze(out AWCount, out ScanCount, out ScanMaxCount);
                Result.Add((int)nudMaskTime.Value, ScanCount);
            }
            Best = Result.First(x => (x.Value == Result.Values.Min()));
            nudMaskTime.Value = Best.Key;

        }*/
        private void btnOptimize_Click(object sender, EventArgs e)
        {
            Optimize();

        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ((GA)e.Argument).RunEpoch((int)nudEpoch.Value, () => { pbGA.Invoke(new MethodInvoker(delegate { pbGA.Value = ((GA)e.Argument).CurrentEpochGeneration; })); lblBestFitness.Invoke(new MethodInvoker(delegate { lblBestFitness.Text = ((GA)e.Argument).BestIndividual.Fitness.ToString("0.00"); })); }, null);
            e.Result = e.Argument;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            nudScanTime.Value = (decimal)Math.Abs(((GA)e.Result).BestIndividual.Genotype[0] * 100);
            nudMaskTime.Value = (decimal)Math.Abs(((GA)e.Result).BestIndividual.Genotype[1] * 100);
            nudThresold.Value = (decimal)Math.Abs(((GA)e.Result).BestIndividual.Genotype[2] * 100);
            nudRet.Value = 0;//(decimal)Math.Abs(ga.BestIndividual.Genotype[3] * 100);

            MessageBox.Show("Fine");
        }

        List<double> gPlayTime;
        int iPlayTime = 0;
        //System.Media.SoundPlayer pWave = new System.Media.SoundPlayer();
        System.IO.Pipes.NamedPipeServerStream MIDIOut = new System.IO.Pipes.NamedPipeServerStream("MIDIPipe");

        private void btnTest_Click(object sender, EventArgs e)
        {
            if (tmrTest.Enabled) { tmrTest.Stop(); return; }
            
            iPlayTime = 0;

            if (!MIDIOut.IsConnected && MessageBox.Show("Aspetto il collegamento?", "microDRUM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                MIDIOut.WaitForConnection();
            }
            //pWave.SoundLocation = @"c:\snare.wav";
            if (chkSpeedTest.Checked)
            {
                tmrTest.Interval = 2*(int)nudMaskTime.Value;
            }
            else
            {
                gPlayTime = Test(gPairList);
                tmrTest.Interval = (int)gPlayTime[iPlayTime++];
            }
            tmrTest.Start();
        }

        private List<double> Test(List<Pair> PairList)
        {
            List<double> PlayTime = new List<double>();

            for (int i = 0; i < PairList.Count - 1; i++)
            {
                int due = i + 1;

                if (PairList[i].Status == 1 && PairList[due].Status != 1)
                    PlayTime.Add(PairList[i].X);

            }

            return PlayTime;
        }

        private void tmrTest_Tick(object sender, EventArgs e)
        {
            if (chkSpeedTest.Checked)
            {
                if (MIDIOut.IsConnected)
                {
                    MIDIOut.Write(new byte[] { 0x90, (byte)nudNote.Value, 127 }, 0, 3);
                }
            }
            else
            {
                if (gPlayTime.Count <= iPlayTime)
                {
                    tmrTest.Stop();
                    return;
                }

                if (gPlayTime.Count <= iPlayTime + 1) { tmrTest.Stop(); return; }
                int tmpPlayTime = (int)gPlayTime[iPlayTime + 1];

                int i = 0;
                while (gPairList[i].X < (double)tmpPlayTime) i++;
                hScrollBar.Value = i > hScrollBar.Maximum ? hScrollBar.Maximum : i - 100;
                UpdateGraph(gPairList);


                tmrTest.Interval = tmpPlayTime - (int)gPlayTime[iPlayTime];
                iPlayTime++;

                //pWave.Play();
                if (MIDIOut.IsConnected)
                {
                    MIDIOut.Write(new byte[] { 0x90, (byte)nudNote.Value, (byte)(gPairList[i].MaxReading / 8.0) }, 0, 3);
                }
            }
            
        }
    }
}

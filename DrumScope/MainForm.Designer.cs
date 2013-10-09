namespace DrumScope
{
    partial class MainForm
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Liberare le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.zedGraphControl = new ZedGraph.ZedGraphControl();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.hScrollBar = new System.Windows.Forms.HScrollBar();
            this.btnSimulate = new System.Windows.Forms.Button();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.nudThresold = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudScanTime = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.nudMaskTime = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nudAWin = new System.Windows.Forms.NumericUpDown();
            this.btnPrev = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.lblAWC = new System.Windows.Forms.Label();
            this.lblScanCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nudRet = new System.Windows.Forms.NumericUpDown();
            this.nudRandRemove = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.chkABS = new System.Windows.Forms.CheckBox();
            this.lblScanMaxCount = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnOptimize = new System.Windows.Forms.Button();
            this.pbGA = new System.Windows.Forms.ProgressBar();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudEpoch = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.nudNote = new System.Windows.Forms.NumericUpDown();
            this.chkSpeedTest = new System.Windows.Forms.CheckBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.tmrTest = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.nudThresold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAWin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandRemove)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpoch)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNote)).BeginInit();
            this.SuspendLayout();
            // 
            // zedGraphControl
            // 
            this.zedGraphControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.zedGraphControl.IsEnableVZoom = false;
            this.zedGraphControl.IsEnableWheelZoom = false;
            this.zedGraphControl.IsShowContextMenu = false;
            this.zedGraphControl.Location = new System.Drawing.Point(3, 3);
            this.zedGraphControl.Name = "zedGraphControl";
            this.zedGraphControl.ScrollGrace = 0D;
            this.zedGraphControl.ScrollMaxX = 0D;
            this.zedGraphControl.ScrollMaxY = 0D;
            this.zedGraphControl.ScrollMaxY2 = 0D;
            this.zedGraphControl.ScrollMinX = 0D;
            this.zedGraphControl.ScrollMinY = 0D;
            this.zedGraphControl.ScrollMinY2 = 0D;
            this.zedGraphControl.Size = new System.Drawing.Size(1022, 378);
            this.zedGraphControl.TabIndex = 0;
            // 
            // btnOpen
            // 
            this.btnOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOpen.Location = new System.Drawing.Point(7, 92);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // hScrollBar
            // 
            this.hScrollBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hScrollBar.Location = new System.Drawing.Point(3, 384);
            this.hScrollBar.Name = "hScrollBar";
            this.hScrollBar.Size = new System.Drawing.Size(928, 16);
            this.hScrollBar.TabIndex = 2;
            this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
            // 
            // btnSimulate
            // 
            this.btnSimulate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSimulate.Location = new System.Drawing.Point(188, 90);
            this.btnSimulate.Name = "btnSimulate";
            this.btnSimulate.Size = new System.Drawing.Size(75, 23);
            this.btnSimulate.TabIndex = 3;
            this.btnSimulate.Text = "Simulate";
            this.btnSimulate.UseVisualStyleBackColor = true;
            this.btnSimulate.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAnalyze.Location = new System.Drawing.Point(9, 90);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(75, 23);
            this.btnAnalyze.TabIndex = 4;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // nudThresold
            // 
            this.nudThresold.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudThresold.Location = new System.Drawing.Point(73, 13);
            this.nudThresold.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudThresold.Name = "nudThresold";
            this.nudThresold.Size = new System.Drawing.Size(66, 20);
            this.nudThresold.TabIndex = 5;
            this.nudThresold.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Thresold:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "ScanTime:";
            // 
            // nudScanTime
            // 
            this.nudScanTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudScanTime.Location = new System.Drawing.Point(73, 39);
            this.nudScanTime.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.nudScanTime.Name = "nudScanTime";
            this.nudScanTime.Size = new System.Drawing.Size(66, 20);
            this.nudScanTime.TabIndex = 7;
            this.nudScanTime.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "MaskTime:";
            // 
            // nudMaskTime
            // 
            this.nudMaskTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudMaskTime.Location = new System.Drawing.Point(73, 67);
            this.nudMaskTime.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudMaskTime.Name = "nudMaskTime";
            this.nudMaskTime.Size = new System.Drawing.Size(66, 20);
            this.nudMaskTime.TabIndex = 9;
            this.nudMaskTime.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(155, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "AWin:";
            // 
            // nudAWin
            // 
            this.nudAWin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudAWin.Location = new System.Drawing.Point(197, 13);
            this.nudAWin.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.nudAWin.Name = "nudAWin";
            this.nudAWin.Size = new System.Drawing.Size(66, 20);
            this.nudAWin.TabIndex = 11;
            this.nudAWin.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // btnPrev
            // 
            this.btnPrev.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrev.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrev.Location = new System.Drawing.Point(945, 384);
            this.btnPrev.Name = "btnPrev";
            this.btnPrev.Size = new System.Drawing.Size(34, 16);
            this.btnPrev.TabIndex = 13;
            this.btnPrev.Text = "<<";
            this.btnPrev.UseVisualStyleBackColor = true;
            this.btnPrev.Click += new System.EventHandler(this.btnPrev_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.Location = new System.Drawing.Point(985, 384);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(34, 16);
            this.btnNext.TabIndex = 14;
            this.btnNext.Text = ">>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // lblAWC
            // 
            this.lblAWC.AutoSize = true;
            this.lblAWC.Location = new System.Drawing.Point(6, 16);
            this.lblAWC.Name = "lblAWC";
            this.lblAWC.Size = new System.Drawing.Size(56, 13);
            this.lblAWC.TabIndex = 15;
            this.lblAWC.Text = "AWCount:";
            // 
            // lblScanCount
            // 
            this.lblScanCount.AutoSize = true;
            this.lblScanCount.Location = new System.Drawing.Point(6, 36);
            this.lblScanCount.Name = "lblScanCount";
            this.lblScanCount.Size = new System.Drawing.Size(63, 13);
            this.lblScanCount.TabIndex = 16;
            this.lblScanCount.Text = "ScanCount:";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(31, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Ret:";
            // 
            // nudRet
            // 
            this.nudRet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudRet.Location = new System.Drawing.Point(73, 93);
            this.nudRet.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudRet.Name = "nudRet";
            this.nudRet.Size = new System.Drawing.Size(66, 20);
            this.nudRet.TabIndex = 17;
            this.nudRet.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // nudRandRemove
            // 
            this.nudRandRemove.Location = new System.Drawing.Point(6, 19);
            this.nudRandRemove.Name = "nudRandRemove";
            this.nudRandRemove.Size = new System.Drawing.Size(47, 20);
            this.nudRandRemove.TabIndex = 20;
            this.nudRandRemove.Value = new decimal(new int[] {
            97,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(59, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(15, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "%";
            // 
            // chkABS
            // 
            this.chkABS.AutoSize = true;
            this.chkABS.Checked = true;
            this.chkABS.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkABS.Location = new System.Drawing.Point(8, 45);
            this.chkABS.Name = "chkABS";
            this.chkABS.Size = new System.Drawing.Size(38, 17);
            this.chkABS.TabIndex = 22;
            this.chkABS.Text = ">0";
            this.chkABS.UseVisualStyleBackColor = true;
            // 
            // lblScanMaxCount
            // 
            this.lblScanMaxCount.AutoSize = true;
            this.lblScanMaxCount.Location = new System.Drawing.Point(6, 56);
            this.lblScanMaxCount.Name = "lblScanMaxCount";
            this.lblScanMaxCount.Size = new System.Drawing.Size(83, 13);
            this.lblScanMaxCount.TabIndex = 23;
            this.lblScanMaxCount.Text = "ScanMaxCount:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblAWC);
            this.groupBox1.Controls.Add(this.lblScanMaxCount);
            this.groupBox1.Controls.Add(this.lblScanCount);
            this.groupBox1.Controls.Add(this.btnAnalyze);
            this.groupBox1.Location = new System.Drawing.Point(283, 403);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 121);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.btnSimulate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.nudThresold);
            this.groupBox2.Controls.Add(this.nudScanTime);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.nudMaskTime);
            this.groupBox2.Controls.Add(this.nudRet);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.nudAWin);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(3, 403);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 121);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.btnOpen);
            this.groupBox3.Controls.Add(this.nudRandRemove);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.chkABS);
            this.groupBox3.Location = new System.Drawing.Point(937, 403);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(88, 121);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            // 
            // btnOptimize
            // 
            this.btnOptimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOptimize.Location = new System.Drawing.Point(69, 90);
            this.btnOptimize.Name = "btnOptimize";
            this.btnOptimize.Size = new System.Drawing.Size(75, 23);
            this.btnOptimize.TabIndex = 27;
            this.btnOptimize.Text = "Optimize";
            this.btnOptimize.UseVisualStyleBackColor = true;
            this.btnOptimize.Click += new System.EventHandler(this.btnOptimize_Click);
            // 
            // pbGA
            // 
            this.pbGA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pbGA.Location = new System.Drawing.Point(6, 61);
            this.pbGA.Name = "pbGA";
            this.pbGA.Size = new System.Drawing.Size(138, 23);
            this.pbGA.TabIndex = 28;
            // 
            // lblBestFitness
            // 
            this.lblBestFitness.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Location = new System.Drawing.Point(6, 41);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(16, 13);
            this.lblBestFitness.TabIndex = 29;
            this.lblBestFitness.Text = "---";
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.nudEpoch);
            this.groupBox4.Controls.Add(this.pbGA);
            this.groupBox4.Controls.Add(this.btnOptimize);
            this.groupBox4.Controls.Add(this.lblBestFitness);
            this.groupBox4.Location = new System.Drawing.Point(430, 403);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(150, 121);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 13);
            this.label8.TabIndex = 31;
            this.label8.Text = "Epoch:";
            // 
            // nudEpoch
            // 
            this.nudEpoch.Location = new System.Drawing.Point(90, 18);
            this.nudEpoch.Name = "nudEpoch";
            this.nudEpoch.Size = new System.Drawing.Size(54, 20);
            this.nudEpoch.TabIndex = 30;
            this.nudEpoch.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.nudNote);
            this.groupBox5.Controls.Add(this.chkSpeedTest);
            this.groupBox5.Controls.Add(this.btnTest);
            this.groupBox5.Location = new System.Drawing.Point(586, 403);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(345, 121);
            this.groupBox5.TabIndex = 31;
            this.groupBox5.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(33, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Note:";
            // 
            // nudNote
            // 
            this.nudNote.Location = new System.Drawing.Point(45, 13);
            this.nudNote.Name = "nudNote";
            this.nudNote.Size = new System.Drawing.Size(52, 20);
            this.nudNote.TabIndex = 2;
            this.nudNote.Value = new decimal(new int[] {
            37,
            0,
            0,
            0});
            // 
            // chkSpeedTest
            // 
            this.chkSpeedTest.AutoSize = true;
            this.chkSpeedTest.Location = new System.Drawing.Point(9, 45);
            this.chkSpeedTest.Name = "chkSpeedTest";
            this.chkSpeedTest.Size = new System.Drawing.Size(81, 17);
            this.chkSpeedTest.TabIndex = 1;
            this.chkSpeedTest.Text = "Speed Test";
            this.chkSpeedTest.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(264, 90);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 0;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // tmrTest
            // 
            this.tmrTest.Tick += new System.EventHandler(this.tmrTest_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 523);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrev);
            this.Controls.Add(this.hScrollBar);
            this.Controls.Add(this.zedGraphControl);
            this.MinimumSize = new System.Drawing.Size(1022, 550);
            this.Name = "MainForm";
            this.Text = "DrumScope";
            ((System.ComponentModel.ISupportInitialize)(this.nudThresold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudScanTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMaskTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudAWin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudRandRemove)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudEpoch)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudNote)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private ZedGraph.ZedGraphControl zedGraphControl;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.HScrollBar hScrollBar;
        private System.Windows.Forms.Button btnSimulate;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.NumericUpDown nudThresold;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nudScanTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown nudMaskTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nudAWin;
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Label lblAWC;
        private System.Windows.Forms.Label lblScanCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nudRet;
        private System.Windows.Forms.NumericUpDown nudRandRemove;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkABS;
        private System.Windows.Forms.Label lblScanMaxCount;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnOptimize;
        private System.Windows.Forms.ProgressBar pbGA;
        private System.Windows.Forms.Label lblBestFitness;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.CheckBox chkSpeedTest;
        private System.Windows.Forms.Timer tmrTest;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudNote;
        private System.Windows.Forms.NumericUpDown nudEpoch;
        private System.Windows.Forms.Label label8;
    }
}
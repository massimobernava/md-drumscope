namespace PicoGA.FindMatrixGui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pitchPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.generationLabel = new System.Windows.Forms.Label();
            this.stopButton = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pitchPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pitchPictureBox
            // 
            this.pitchPictureBox.Location = new System.Drawing.Point(12, 39);
            this.pitchPictureBox.Name = "pitchPictureBox";
            this.pitchPictureBox.Size = new System.Drawing.Size(809, 502);
            this.pitchPictureBox.TabIndex = 0;
            this.pitchPictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Generation:";
            // 
            // generationLabel
            // 
            this.generationLabel.AutoSize = true;
            this.generationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generationLabel.Location = new System.Drawing.Point(12, 23);
            this.generationLabel.Name = "generationLabel";
            this.generationLabel.Size = new System.Drawing.Size(43, 13);
            this.generationLabel.TabIndex = 2;
            this.generationLabel.Text = "(none)";
            // 
            // stopButton
            // 
            this.stopButton.Location = new System.Drawing.Point(746, 10);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(75, 23);
            this.stopButton.TabIndex = 3;
            this.stopButton.Text = "Stop";
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(665, 10);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 560);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.stopButton);
            this.Controls.Add(this.generationLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pitchPictureBox);
            this.Name = "MainForm";
            this.Text = "PicoGA.FindMatrixGui";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pitchPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pitchPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label generationLabel;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button buttonStart;
    }
}


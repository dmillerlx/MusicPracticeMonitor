namespace MusicPracticeMonitor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.lblTotalSessionTime = new System.Windows.Forms.Label();
            this.lblActiveTime = new System.Windows.Forms.Label();
            this.lblIdleTime = new System.Windows.Forms.Label();
            this.lblPercentActive = new System.Windows.Forms.Label();
            this.lblBreakCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblCurrentSoundLevel = new System.Windows.Forms.Label();
            this.progressBarSoundLevel = new System.Windows.Forms.ProgressBar();
            this.trackBarThreshold = new System.Windows.Forms.TrackBar();
            this.label7 = new System.Windows.Forms.Label();
            this.lblThresholdValue = new System.Windows.Forms.Label();
            this.lblSessionState = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(25, 457);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 60);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button2.Location = new System.Drawing.Point(450, 457);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button3.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button3.Location = new System.Drawing.Point(177, 457);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 60);
            this.button3.TabIndex = 2;
            this.button3.Text = "Pause";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button4.Location = new System.Drawing.Point(308, 457);
            this.button4.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(125, 60);
            this.button4.TabIndex = 3;
            this.button4.Text = "Resume";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.btnResume_Click);
            // 
            // lblTotalSessionTime
            // 
            this.lblTotalSessionTime.AutoSize = true;
            this.lblTotalSessionTime.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSessionTime.Location = new System.Drawing.Point(354, 45);
            this.lblTotalSessionTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSessionTime.Name = "lblTotalSessionTime";
            this.lblTotalSessionTime.Size = new System.Drawing.Size(83, 33);
            this.lblTotalSessionTime.TabIndex = 4;
            this.lblTotalSessionTime.Text = "label1";
            // 
            // lblActiveTime
            // 
            this.lblActiveTime.AutoSize = true;
            this.lblActiveTime.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActiveTime.Location = new System.Drawing.Point(43, 100);
            this.lblActiveTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveTime.Name = "lblActiveTime";
            this.lblActiveTime.Size = new System.Drawing.Size(83, 33);
            this.lblActiveTime.TabIndex = 5;
            this.lblActiveTime.Text = "label1";
            // 
            // lblIdleTime
            // 
            this.lblIdleTime.AutoSize = true;
            this.lblIdleTime.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblIdleTime.Location = new System.Drawing.Point(41, 215);
            this.lblIdleTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdleTime.Name = "lblIdleTime";
            this.lblIdleTime.Size = new System.Drawing.Size(83, 33);
            this.lblIdleTime.TabIndex = 6;
            this.lblIdleTime.Text = "label1";
            // 
            // lblPercentActive
            // 
            this.lblPercentActive.AutoSize = true;
            this.lblPercentActive.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPercentActive.Location = new System.Drawing.Point(354, 182);
            this.lblPercentActive.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPercentActive.Name = "lblPercentActive";
            this.lblPercentActive.Size = new System.Drawing.Size(137, 57);
            this.lblPercentActive.TabIndex = 7;
            this.lblPercentActive.Text = "label1";
            // 
            // lblBreakCount
            // 
            this.lblBreakCount.AutoSize = true;
            this.lblBreakCount.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblBreakCount.Location = new System.Drawing.Point(174, 323);
            this.lblBreakCount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBreakCount.Name = "lblBreakCount";
            this.lblBreakCount.Size = new System.Drawing.Size(63, 25);
            this.lblBreakCount.TabIndex = 8;
            this.lblBreakCount.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(283, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 33);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Session Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(43, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 33);
            this.label2.TabIndex = 10;
            this.label2.Text = "Active Time";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(40, 182);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 33);
            this.label3.TabIndex = 11;
            this.label3.Text = "Idle Time";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(270, 125);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(298, 57);
            this.label4.TabIndex = 12;
            this.label4.Text = "Percent Active";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(43, 323);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(117, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Break Count";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(43, 361);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 25);
            this.label6.TabIndex = 15;
            this.label6.Text = "Sound Level";
            // 
            // lblCurrentSoundLevel
            // 
            this.lblCurrentSoundLevel.AutoSize = true;
            this.lblCurrentSoundLevel.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCurrentSoundLevel.Location = new System.Drawing.Point(174, 361);
            this.lblCurrentSoundLevel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCurrentSoundLevel.Name = "lblCurrentSoundLevel";
            this.lblCurrentSoundLevel.Size = new System.Drawing.Size(63, 25);
            this.lblCurrentSoundLevel.TabIndex = 14;
            this.lblCurrentSoundLevel.Text = "label1";
            // 
            // progressBarSoundLevel
            // 
            this.progressBarSoundLevel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBarSoundLevel.Location = new System.Drawing.Point(25, 561);
            this.progressBarSoundLevel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.progressBarSoundLevel.Name = "progressBarSoundLevel";
            this.progressBarSoundLevel.Size = new System.Drawing.Size(553, 22);
            this.progressBarSoundLevel.TabIndex = 16;
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThreshold.Location = new System.Drawing.Point(11, 540);
            this.trackBarThreshold.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(580, 45);
            this.trackBarThreshold.TabIndex = 17;
            this.trackBarThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackBarThreshold.ValueChanged += new System.EventHandler(this.trackBarThreshold_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(5, 399);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 25);
            this.label7.TabIndex = 19;
            this.label7.Text = "Sound Threshold";
            // 
            // lblThresholdValue
            // 
            this.lblThresholdValue.AutoSize = true;
            this.lblThresholdValue.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblThresholdValue.Location = new System.Drawing.Point(174, 399);
            this.lblThresholdValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblThresholdValue.Name = "lblThresholdValue";
            this.lblThresholdValue.Size = new System.Drawing.Size(63, 25);
            this.lblThresholdValue.TabIndex = 18;
            this.lblThresholdValue.Text = "label1";
            // 
            // lblSessionState
            // 
            this.lblSessionState.AutoSize = true;
            this.lblSessionState.Font = new System.Drawing.Font("Arial Black", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSessionState.Location = new System.Drawing.Point(302, 290);
            this.lblSessionState.Name = "lblSessionState";
            this.lblSessionState.Size = new System.Drawing.Size(189, 68);
            this.lblSessionState.TabIndex = 20;
            this.lblSessionState.Text = "label8";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 595);
            this.Controls.Add(this.lblSessionState);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblThresholdValue);
            this.Controls.Add(this.progressBarSoundLevel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lblCurrentSoundLevel);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblBreakCount);
            this.Controls.Add(this.lblPercentActive);
            this.Controls.Add(this.lblIdleTime);
            this.Controls.Add(this.lblActiveTime);
            this.Controls.Add(this.lblTotalSessionTime);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBarThreshold);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Monitor";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label lblTotalSessionTime;
        private Label lblActiveTime;
        private Label lblIdleTime;
        private Label lblPercentActive;
        private Label lblBreakCount;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label lblCurrentSoundLevel;
        private ProgressBar progressBarSoundLevel;
        private TrackBar trackBarThreshold;
        private Label label7;
        private Label lblThresholdValue;
        private Label lblSessionState;
    }
}
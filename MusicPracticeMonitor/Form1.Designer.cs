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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
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
            this.trackBarLowFreq = new System.Windows.Forms.TrackBar();
            this.trackBarHighFreq = new System.Windows.Forms.TrackBar();
            this.trackBarEnergy = new System.Windows.Forms.TrackBar();
            this.progressBarMusicRatio = new System.Windows.Forms.ProgressBar();
            this.lblLowFreq = new System.Windows.Forms.Label();
            this.lblHighFreq = new System.Windows.Forms.Label();
            this.lblEnergy = new System.Windows.Forms.Label();
            this.lblMusicRatio = new System.Windows.Forms.Label();
            this.comboBoxDetectionMode = new System.Windows.Forms.ComboBox();
            this.lblSustainedDb = new System.Windows.Forms.Label();
            this.trackBarSustainedDb = new System.Windows.Forms.TrackBar();
            this.lblSustainedDuration = new System.Windows.Forms.Label();
            this.numericUpDownSustainedDuration = new System.Windows.Forms.NumericUpDown();
            this.lblDecibels = new System.Windows.Forms.Label();
            this.progressBarDecibels = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelCountDown = new System.Windows.Forms.Label();
            this.textBoxDelay = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLowFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHighFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnergy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainedDb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSustainedDuration)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(25, 466);
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
            this.button2.Location = new System.Drawing.Point(184, 466);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(118, 60);
            this.button2.TabIndex = 1;
            this.button2.Text = "Reset";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // lblTotalSessionTime
            // 
            this.lblTotalSessionTime.AutoSize = true;
            this.lblTotalSessionTime.Font = new System.Drawing.Font("Arial Narrow", 63.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTotalSessionTime.ForeColor = System.Drawing.Color.Red;
            this.lblTotalSessionTime.Location = new System.Drawing.Point(303, 76);
            this.lblTotalSessionTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTotalSessionTime.Name = "lblTotalSessionTime";
            this.lblTotalSessionTime.Size = new System.Drawing.Size(240, 99);
            this.lblTotalSessionTime.TabIndex = 4;
            this.lblTotalSessionTime.Text = "label1";
            this.lblTotalSessionTime.Click += new System.EventHandler(this.lblTotalSessionTime_Click);
            // 
            // lblActiveTime
            // 
            this.lblActiveTime.AutoSize = true;
            this.lblActiveTime.Font = new System.Drawing.Font("Arial Narrow", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblActiveTime.ForeColor = System.Drawing.Color.Red;
            this.lblActiveTime.Location = new System.Drawing.Point(43, 100);
            this.lblActiveTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblActiveTime.Name = "lblActiveTime";
            this.lblActiveTime.Size = new System.Drawing.Size(137, 57);
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
            this.lblPercentActive.Location = new System.Drawing.Point(373, 257);
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
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 39.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(234, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(424, 63);
            this.label1.TabIndex = 9;
            this.label1.Text = "Total Session Time";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(43, 60);
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
            this.label4.Location = new System.Drawing.Point(287, 191);
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
            this.progressBarSoundLevel.Location = new System.Drawing.Point(25, 570);
            this.progressBarSoundLevel.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.progressBarSoundLevel.Name = "progressBarSoundLevel";
            this.progressBarSoundLevel.Size = new System.Drawing.Size(1462, 22);
            this.progressBarSoundLevel.TabIndex = 16;
            // 
            // trackBarThreshold
            // 
            this.trackBarThreshold.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarThreshold.Location = new System.Drawing.Point(11, 549);
            this.trackBarThreshold.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.trackBarThreshold.Name = "trackBarThreshold";
            this.trackBarThreshold.Size = new System.Drawing.Size(1489, 45);
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
            this.lblSessionState.Location = new System.Drawing.Point(354, 328);
            this.lblSessionState.Name = "lblSessionState";
            this.lblSessionState.Size = new System.Drawing.Size(189, 68);
            this.lblSessionState.TabIndex = 20;
            this.lblSessionState.Text = "label8";
            // 
            // trackBarLowFreq
            // 
            this.trackBarLowFreq.Location = new System.Drawing.Point(700, 95);
            this.trackBarLowFreq.Name = "trackBarLowFreq";
            this.trackBarLowFreq.Size = new System.Drawing.Size(341, 45);
            this.trackBarLowFreq.TabIndex = 22;
            this.trackBarLowFreq.ValueChanged += new System.EventHandler(this.trackBarLowFreq_ValueChanged);
            // 
            // trackBarHighFreq
            // 
            this.trackBarHighFreq.Location = new System.Drawing.Point(700, 215);
            this.trackBarHighFreq.Name = "trackBarHighFreq";
            this.trackBarHighFreq.Size = new System.Drawing.Size(341, 45);
            this.trackBarHighFreq.TabIndex = 23;
            this.trackBarHighFreq.ValueChanged += new System.EventHandler(this.trackBarHighFreq_ValueChanged);
            // 
            // trackBarEnergy
            // 
            this.trackBarEnergy.Location = new System.Drawing.Point(700, 303);
            this.trackBarEnergy.Name = "trackBarEnergy";
            this.trackBarEnergy.Size = new System.Drawing.Size(341, 45);
            this.trackBarEnergy.TabIndex = 24;
            this.trackBarEnergy.ValueChanged += new System.EventHandler(this.trackBarEnergy_ValueChanged);
            // 
            // progressBarMusicRatio
            // 
            this.progressBarMusicRatio.Location = new System.Drawing.Point(703, 399);
            this.progressBarMusicRatio.Name = "progressBarMusicRatio";
            this.progressBarMusicRatio.Size = new System.Drawing.Size(338, 23);
            this.progressBarMusicRatio.TabIndex = 25;
            // 
            // lblLowFreq
            // 
            this.lblLowFreq.AutoSize = true;
            this.lblLowFreq.Location = new System.Drawing.Point(826, 63);
            this.lblLowFreq.Name = "lblLowFreq";
            this.lblLowFreq.Size = new System.Drawing.Size(38, 15);
            this.lblLowFreq.TabIndex = 26;
            this.lblLowFreq.Text = "label8";
            // 
            // lblHighFreq
            // 
            this.lblHighFreq.AutoSize = true;
            this.lblHighFreq.Location = new System.Drawing.Point(826, 182);
            this.lblHighFreq.Name = "lblHighFreq";
            this.lblHighFreq.Size = new System.Drawing.Size(38, 15);
            this.lblHighFreq.TabIndex = 28;
            this.lblHighFreq.Text = "label8";
            // 
            // lblEnergy
            // 
            this.lblEnergy.AutoSize = true;
            this.lblEnergy.Location = new System.Drawing.Point(826, 275);
            this.lblEnergy.Name = "lblEnergy";
            this.lblEnergy.Size = new System.Drawing.Size(38, 15);
            this.lblEnergy.TabIndex = 30;
            this.lblEnergy.Text = "label8";
            // 
            // lblMusicRatio
            // 
            this.lblMusicRatio.AutoSize = true;
            this.lblMusicRatio.Location = new System.Drawing.Point(826, 371);
            this.lblMusicRatio.Name = "lblMusicRatio";
            this.lblMusicRatio.Size = new System.Drawing.Size(38, 15);
            this.lblMusicRatio.TabIndex = 31;
            this.lblMusicRatio.Text = "label8";
            // 
            // comboBoxDetectionMode
            // 
            this.comboBoxDetectionMode.FormattingEnabled = true;
            this.comboBoxDetectionMode.Location = new System.Drawing.Point(978, 479);
            this.comboBoxDetectionMode.Name = "comboBoxDetectionMode";
            this.comboBoxDetectionMode.Size = new System.Drawing.Size(167, 23);
            this.comboBoxDetectionMode.TabIndex = 32;
            this.comboBoxDetectionMode.SelectedIndexChanged += new System.EventHandler(this.comboBoxDetectionMode_SelectedIndexChanged);
            // 
            // lblSustainedDb
            // 
            this.lblSustainedDb.AutoSize = true;
            this.lblSustainedDb.Location = new System.Drawing.Point(1214, 60);
            this.lblSustainedDb.Name = "lblSustainedDb";
            this.lblSustainedDb.Size = new System.Drawing.Size(38, 15);
            this.lblSustainedDb.TabIndex = 33;
            this.lblSustainedDb.Text = "label8";
            // 
            // trackBarSustainedDb
            // 
            this.trackBarSustainedDb.Location = new System.Drawing.Point(1107, 88);
            this.trackBarSustainedDb.Name = "trackBarSustainedDb";
            this.trackBarSustainedDb.Size = new System.Drawing.Size(341, 45);
            this.trackBarSustainedDb.TabIndex = 34;
            this.trackBarSustainedDb.ValueChanged += new System.EventHandler(this.trackBarSustainedDb_ValueChanged);
            // 
            // lblSustainedDuration
            // 
            this.lblSustainedDuration.AutoSize = true;
            this.lblSustainedDuration.Location = new System.Drawing.Point(1107, 176);
            this.lblSustainedDuration.Name = "lblSustainedDuration";
            this.lblSustainedDuration.Size = new System.Drawing.Size(38, 15);
            this.lblSustainedDuration.TabIndex = 35;
            this.lblSustainedDuration.Text = "label8";
            // 
            // numericUpDownSustainedDuration
            // 
            this.numericUpDownSustainedDuration.Location = new System.Drawing.Point(1265, 174);
            this.numericUpDownSustainedDuration.Name = "numericUpDownSustainedDuration";
            this.numericUpDownSustainedDuration.Size = new System.Drawing.Size(77, 23);
            this.numericUpDownSustainedDuration.TabIndex = 36;
            this.numericUpDownSustainedDuration.ValueChanged += new System.EventHandler(this.numericUpDownSustainedDuration_ValueChanged);
            // 
            // lblDecibels
            // 
            this.lblDecibels.AutoSize = true;
            this.lblDecibels.Location = new System.Drawing.Point(1240, 371);
            this.lblDecibels.Name = "lblDecibels";
            this.lblDecibels.Size = new System.Drawing.Size(38, 15);
            this.lblDecibels.TabIndex = 37;
            this.lblDecibels.Text = "label8";
            // 
            // progressBarDecibels
            // 
            this.progressBarDecibels.Location = new System.Drawing.Point(1107, 399);
            this.progressBarDecibels.Name = "progressBarDecibels";
            this.progressBarDecibels.Size = new System.Drawing.Size(338, 23);
            this.progressBarDecibels.TabIndex = 38;
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(663, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 428);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Frequency Filter";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(1084, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(390, 428);
            this.groupBox2.TabIndex = 40;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Sustained Energy Filter";
            // 
            // labelCountDown
            // 
            this.labelCountDown.AutoSize = true;
            this.labelCountDown.Font = new System.Drawing.Font("Arial Black", 144F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelCountDown.ForeColor = System.Drawing.Color.Red;
            this.labelCountDown.Location = new System.Drawing.Point(184, 157);
            this.labelCountDown.Name = "labelCountDown";
            this.labelCountDown.Size = new System.Drawing.Size(755, 270);
            this.labelCountDown.TabIndex = 43;
            this.labelCountDown.Text = "label8";
            this.labelCountDown.Visible = false;
            // 
            // textBoxDelay
            // 
            this.textBoxDelay.Location = new System.Drawing.Point(442, 479);
            this.textBoxDelay.Name = "textBoxDelay";
            this.textBoxDelay.Size = new System.Drawing.Size(66, 23);
            this.textBoxDelay.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial Narrow", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label8.Location = new System.Drawing.Point(378, 477);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 25);
            this.label8.TabIndex = 42;
            this.label8.Text = "Delay";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1510, 604);
            this.Controls.Add(this.labelCountDown);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxDelay);
            this.Controls.Add(this.progressBarDecibels);
            this.Controls.Add(this.lblDecibels);
            this.Controls.Add(this.numericUpDownSustainedDuration);
            this.Controls.Add(this.lblSustainedDuration);
            this.Controls.Add(this.trackBarSustainedDb);
            this.Controls.Add(this.lblSustainedDb);
            this.Controls.Add(this.comboBoxDetectionMode);
            this.Controls.Add(this.lblMusicRatio);
            this.Controls.Add(this.lblEnergy);
            this.Controls.Add(this.lblHighFreq);
            this.Controls.Add(this.lblLowFreq);
            this.Controls.Add(this.progressBarMusicRatio);
            this.Controls.Add(this.trackBarEnergy);
            this.Controls.Add(this.trackBarHighFreq);
            this.Controls.Add(this.trackBarLowFreq);
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
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBarThreshold);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Music Monitor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLowFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarHighFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarEnergy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarSustainedDb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSustainedDuration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button2;
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
        private TrackBar trackBarLowFreq;
        private TrackBar trackBarHighFreq;
        private TrackBar trackBarEnergy;
        private ProgressBar progressBarMusicRatio;
        private Label lblLowFreq;
        private Label lblHighFreq;
        private Label lblEnergy;
        private Label lblMusicRatio;
        private ComboBox comboBoxDetectionMode;
        private Label lblSustainedDb;
        private TrackBar trackBarSustainedDb;
        private Label lblSustainedDuration;
        private NumericUpDown numericUpDownSustainedDuration;
        private Label lblDecibels;
        private ProgressBar progressBarDecibels;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private TextBox textBoxDelay;
        private Label label8;
        private System.Windows.Forms.Timer timer1;
        private Label labelCountDown;
    }
}
using System.Globalization;

namespace MusicPracticeMonitor
{
    public partial class Form1 : Form
    {
        // The back?end practice session
        private PracticeSession session;

        // A UI timer to periodically update stats on the form.
        private System.Windows.Forms.Timer uiUpdateTimer;

        RegistryConfig registryConfig = new RegistryConfig("MusicMonitor");

        private PracticeSessionConfig config;
        private MicMonitor micMonitor;

        public Form1()
        {
            InitializeComponent();

            // Create and configure a new PracticeSessionConfig.
            //PracticeSessionConfig config = new PracticeSessionConfig
            //{
            //    // Set any values you want to override the defaults.
            //    Gain = 1.0,
            //    SoundThresholdDb = -15.0,
            //    ActiveStateDelay = TimeSpan.FromSeconds(2),
            //    IdleStateDelay = TimeSpan.FromSeconds(10)
            //};

            // Initialize the practice session with the configuration.
            //session = new PracticeSession(config);

            // Setup the UI update timer to tick every 500 milliseconds.
            uiUpdateTimer = new System.Windows.Forms.Timer();
            uiUpdateTimer.Interval = 50; // 500 ms
            uiUpdateTimer.Tick += UiUpdateTimer_Tick;

            // Create a registry config instance using your app name.
            registryConfig = new RegistryConfig("MusicPracticeMonitor");


            config = new PracticeSessionConfig();
            session = new PracticeSession(config);
            micMonitor = new MicMonitor(config);
            micMonitor.SoundLevelAvailable += MicMonitor_SoundLevelAvailable;
        }

        /// <summary>
        /// Updates UI elements with the latest statistics from the session.
        /// </summary>
        private void UiUpdateTimer_Tick(object sender, EventArgs e)
        {
            // Get a snapshot of the current session stats.
            PracticeSessionStats stats = session.GetStats();

            // Update other labels
            lblTotalSessionTime.Text = stats.TotalSessionTime.ToString(@"hh\:mm\:ss");
            lblActiveTime.Text = stats.TotalActiveTime.ToString(@"hh\:mm\:ss");
            lblIdleTime.Text = stats.TotalIdleTime.ToString(@"hh\:mm\:ss");
            lblPercentActive.Text = $"{stats.PercentActive:F2} %";
            lblBreakCount.Text = stats.BreakCount.ToString();

            // Update the current sound level label with the latest decibel value.
            lblCurrentSoundLevel.Text = $"{stats.CurrentSoundLevel:F2} dB";

            // Optionally, update a progress bar to visualize the sound level.
            // For example, if you have a ProgressBar named progressBarSoundLevel:
            // Assume your dB range is between -100 dB (silence) and 0 dB (loudest)
            double minDb = -100;
            double maxDb = 0;
            double levelPercent = (stats.CurrentSoundLevel - minDb) / (maxDb - minDb) * 100.0;
            levelPercent = Math.Max(0, Math.Min(100, levelPercent)); // Clamp between 0 and 100
            progressBarSoundLevel.Value = (int)levelPercent;



            // Determine the current session state text and assign a corresponding color.
            string stateText;
            Color stateColor;

            switch (stats.SessionStatus)
            {
                case SessionStatus.NotStarted:
                    stateText = "Not Started";
                    stateColor = Color.Black; // or any default color
                    break;
                case SessionStatus.Running:
                    // When running, also display whether the audio is Active or Idle.
                    if (stats.CurrentAudioState == AudioState.Active)
                    {
                        stateText = "Active";
                        stateColor = Color.Green;
                    }
                    else // Assume Idle if not active.
                    {
                        stateText = "Idle";
                        stateColor = Color.Red;
                    }
                    break;
                case SessionStatus.Paused:
                    stateText = "Paused";
                    stateColor = Color.Orange;
                    break;
                case SessionStatus.Stopped:
                    stateText = "Ended";
                    stateColor = Color.Gray;
                    break;
                default:
                    stateText = "Unknown";
                    stateColor = Color.Black;
                    break;
            }

            // Update the state label.
            lblSessionState.Text = stateText;
            lblSessionState.ForeColor = stateColor;



            // Retrieve the latest music ratio from the MicMonitor instance.
            // This value is updated on every audio buffer and is between 0 and 1.
            double ratio = session.LastMusicRatio;

            // Map the ratio to a 0-100 range for the progress bar.
            progressBarMusicRatio.Value = (int)(ratio * 100);

            // Update a label to show the ratio as a percentage.
            lblMusicRatio.Text = $"Music Ratio: {ratio:F2}";



        }

            // --- Button event handlers ---
            private void btnStart_Click(object sender, EventArgs e)
        {
            session.Start();
            uiUpdateTimer.Start();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            session.Stop();
            uiUpdateTimer.Stop();

            String stateText = "Ended";
            Color stateColor = Color.Gray;
            // Update the state label.
            lblSessionState.Text = stateText;
            lblSessionState.ForeColor = stateColor;

        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            session.Pause();
        }

        private void btnResume_Click(object sender, EventArgs e)
        {
            session.Resume();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            session.Reset();
            // Optionally update your UI immediately after resetting.
            UpdateLabelsToReset();
        }

        /// <summary>
        /// Resets the UI labels after a session reset.
        /// </summary>
        private void UpdateLabelsToReset()
        {
            lblTotalSessionTime.Text = "00:00:00";
            lblActiveTime.Text = "00:00:00";
            lblIdleTime.Text = "00:00:00";
            lblPercentActive.Text = "0.00 %";
            lblBreakCount.Text = "0";
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            LoadSettings();


            //// Initialize the trackBarThreshold with an appropriate range.
            trackBarThreshold.Minimum = -100; // Silence
            trackBarThreshold.Maximum = 0;    // Maximum loudness
            trackBarThreshold.TickFrequency = 5;

            //// Set its initial value to match your current config threshold.
            //trackBarThreshold.Value = (int)session.Config.SoundThresholdDb;

            //// Update the label to show the current threshold.
            //lblThresholdValue.Text = $"{trackBarThreshold.Value} dB";


            initLabell(lblActiveTime);
            initLabell(lblBreakCount);
            initLabell(lblCurrentSoundLevel);
            initLabell(lblIdleTime);
            initLabell(lblPercentActive);
            initLabell(lblSessionState, "");
            initLabell(lblThresholdValue);
            initLabell(lblTotalSessionTime);
            initLabell(lblDecibels);
            initLabell(lblSustainedDuration);
            initLabell(lblSustainedDb);
            

            //// Retrieve a stored setting, or use a default if not present.
            int ambientThreshold = registryConfig.GetInt("AmbientThreshold", -30);
            //numericUpDownThreshold.Value = ambientThreshold;
            trackBarThreshold.Value = ambientThreshold;



            //// Initialize the low frequency slider.
            trackBarLowFreq.Minimum = 20;     // e.g., 20 Hz
            trackBarLowFreq.Maximum = 500;    // e.g., 500 Hz
            trackBarLowFreq.Value = (int)session.Config.MusicLowFrequency;
            lblLowFreq.Text = $"Low Frequency: {trackBarLowFreq.Value} Hz";

            //// Initialize the high frequency slider.
            trackBarHighFreq.Minimum = 500;   // e.g., 500 Hz
            trackBarHighFreq.Maximum = 10000; // e.g., 10 kHz
            trackBarHighFreq.Value = (int)session.Config.MusicHighFrequency;
            lblHighFreq.Text = $"High Frequency: {trackBarHighFreq.Value} Hz";

            //// Initialize the energy threshold slider.
            //// We'll use 0-100 to represent 0.0 to 1.0 (multiplied by 100).
            trackBarEnergy.Minimum = 0;
            trackBarEnergy.Maximum = 100;
            trackBarEnergy.Value = (int)(session.Config.MusicEnergyThreshold * 100);
            lblEnergy.Text = $"Energy Threshold: {trackBarEnergy.Value}%";

            //// Set up the music ratio progress bar.
            progressBarMusicRatio.Minimum = 0;
            progressBarMusicRatio.Maximum = 100; // We'll map the ratio [0,1] to 0-100

            // Initialize the decibel progress bar.
            progressBarDecibels.Minimum = 0;
            progressBarDecibels.Maximum = 100;



            //// Update UI controls with loaded values.
            //trackBarLowFreq.Value = (int)session.Config.MusicLowFrequency;
            //lblLowFreq.Text = $"Low Frequency: {trackBarLowFreq.Value} Hz";

            //trackBarHighFreq.Value = (int)session.Config.MusicHighFrequency;
            //lblHighFreq.Text = $"High Frequency: {trackBarHighFreq.Value} Hz";

            //trackBarEnergy.Value = (int)(session.Config.MusicEnergyThreshold * 100);
            //lblEnergy.Text = $"Energy Threshold: {trackBarEnergy.Value}%";

            //chkEnableMusicDetection.Checked = session.Config.EnableMusicDetection;

            // Populate the detection mode combo box.
            comboBoxDetectionMode.DataSource = Enum.GetValues(typeof(DetectionMode));
            comboBoxDetectionMode.SelectedItem = config.CurrentDetectionMode;

            // Initialize Frequency Filter controls.
            trackBarLowFreq.Minimum = 20;
            trackBarLowFreq.Maximum = 500;
            trackBarLowFreq.Value = (int)config.MusicLowFrequency;
            lblLowFreq.Text = $"Low Frequency: {trackBarLowFreq.Value} Hz";

            trackBarHighFreq.Minimum = 500;
            trackBarHighFreq.Maximum = 10000;
            trackBarHighFreq.Value = (int)config.MusicHighFrequency;
            lblHighFreq.Text = $"High Frequency: {trackBarHighFreq.Value} Hz";

            trackBarEnergy.Minimum = 0;
            trackBarEnergy.Maximum = 100;
            trackBarEnergy.Value = (int)(config.MusicEnergyThreshold * 100);
            lblEnergy.Text = $"Energy Threshold: {trackBarEnergy.Value}%";

            // Initialize Sustained Energy controls.
            trackBarSustainedDb.Minimum = -100;
            trackBarSustainedDb.Maximum = 0;
            trackBarSustainedDb.Value = (int)config.SustainedEnergyDbThreshold;
            lblSustainedDb.Text = $"Sustained dB Threshold: {trackBarSustainedDb.Value} dB";

            numericUpDownSustainedDuration.Minimum = 1;
            numericUpDownSustainedDuration.Maximum = 10;
            numericUpDownSustainedDuration.Value = (decimal)config.SustainedEnergyRequiredDuration.TotalSeconds;
            lblSustainedDuration.Text = $"Sustained Duration: {numericUpDownSustainedDuration.Value} sec";

            // Start the mic monitor.
            micMonitor.Start();






            init = true;
        }


        private void MicMonitor_SoundLevelAvailable(object sender, SoundLevelEventArgs e)
        {
            if (closing) return;

            try
            {
                // Update UI from the audio callback (marshal to UI thread).
                Invoke(new Action(() =>
                {
                    lblDecibels.Text = $"Decibels: {e.Decibels:F2} dB";
                    // Map e.Decibels from [-100, 0] to [0, 100].
                    int decibelProgress = (int)Math.Round(e.Decibels + 100);
                    if (decibelProgress < progressBarDecibels.Minimum)
                        decibelProgress = progressBarDecibels.Minimum;
                    if (decibelProgress > progressBarDecibels.Maximum)
                        decibelProgress = progressBarDecibels.Maximum;
                    progressBarDecibels.Value = decibelProgress;

                    progressBarMusicRatio.Value = (int)(micMonitor.LastMusicRatio * 100);
                    lblMusicRatio.Text = $"Music Ratio: {micMonitor.LastMusicRatio:F2}";
                }));
            } catch (Exception ex)
            {
                return;
            }
        }

        private void comboBoxDetectionMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!init) return;
            config.CurrentDetectionMode = (DetectionMode)comboBoxDetectionMode.SelectedItem;
        }

        //private void trackBarLowFreq_ValueChanged(object sender, EventArgs e)
        //{
        //    config.MusicLowFrequency = trackBarLowFreq.Value;
        //    lblLowFreq.Text = $"Low Frequency: {trackBarLowFreq.Value} Hz";
        //}

        //private void trackBarHighFreq_ValueChanged(object sender, EventArgs e)
        //{
        //    config.MusicHighFrequency = trackBarHighFreq.Value;
        //    lblHighFreq.Text = $"High Frequency: {trackBarHighFreq.Value} Hz";
        //}

        //private void trackBarEnergy_ValueChanged(object sender, EventArgs e)
        //{
        //    config.MusicEnergyThreshold = trackBarEnergy.Value / 100.0;
        //    lblEnergy.Text = $"Energy Threshold: {trackBarEnergy.Value}%";
        //}

        private void trackBarSustainedDb_ValueChanged(object sender, EventArgs e)
        {
            if (!init) return;

            config.SustainedEnergyDbThreshold = trackBarSustainedDb.Value;
            lblSustainedDb.Text = $"Sustained dB Threshold: {trackBarSustainedDb.Value} dB";
        }

        private void numericUpDownSustainedDuration_ValueChanged(object sender, EventArgs e)
        {
            if (!init) return;

            config.SustainedEnergyRequiredDuration = TimeSpan.FromSeconds((double)numericUpDownSustainedDuration.Value);
            lblSustainedDuration.Text = $"Sustained Duration: {numericUpDownSustainedDuration.Value} sec";
        }



        private void LoadSettings()
        {
            try
            {
                // General settings.
                config.Gain = double.Parse(registryConfig.GetString("Gain", "1.0"), CultureInfo.InvariantCulture);
                config.SoundThresholdDb = double.Parse(registryConfig.GetString("SoundThresholdDb", "-30.0"), CultureInfo.InvariantCulture);
                config.ActiveStateDelay = TimeSpan.FromSeconds(double.Parse(registryConfig.GetString("ActiveStateDelay", "2"), CultureInfo.InvariantCulture));
                config.IdleStateDelay = TimeSpan.FromSeconds(double.Parse(registryConfig.GetString("IdleStateDelay", "10"), CultureInfo.InvariantCulture));

                // Detection mode.
                string modeString = registryConfig.GetString("CurrentDetectionMode", "Normal");
                config.CurrentDetectionMode = (DetectionMode)Enum.Parse(typeof(DetectionMode), modeString);

                // Frequency filter parameters.
                config.MusicLowFrequency = double.Parse(registryConfig.GetString("MusicLowFrequency", "100.0"), CultureInfo.InvariantCulture);
                config.MusicHighFrequency = double.Parse(registryConfig.GetString("MusicHighFrequency", "4000.0"), CultureInfo.InvariantCulture);
                config.MusicEnergyThreshold = double.Parse(registryConfig.GetString("MusicEnergyThreshold", "0.5"), CultureInfo.InvariantCulture);

                // Sustained energy parameters.
                config.SustainedEnergyDbThreshold = double.Parse(registryConfig.GetString("SustainedEnergyDbThreshold", "-30.0"), CultureInfo.InvariantCulture);
                config.SustainedEnergyRequiredDuration = TimeSpan.FromSeconds(double.Parse(registryConfig.GetString("SustainedEnergyRequiredDuration", "2"), CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                // Handle any parsing errors, perhaps log or notify the user.
                MessageBox.Show($"Error loading settings: {ex.Message}");
            }
        }

        private void SaveSettings()
        {
            try
            {
                // General settings.
                registryConfig.SetString("Gain", config.Gain.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("SoundThresholdDb", config.SoundThresholdDb.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("ActiveStateDelay", config.ActiveStateDelay.TotalSeconds.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("IdleStateDelay", config.IdleStateDelay.TotalSeconds.ToString(CultureInfo.InvariantCulture));

                // Detection mode.
                registryConfig.SetString("CurrentDetectionMode", config.CurrentDetectionMode.ToString());

                // Frequency filter parameters.
                registryConfig.SetString("MusicLowFrequency", config.MusicLowFrequency.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("MusicHighFrequency", config.MusicHighFrequency.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("MusicEnergyThreshold", config.MusicEnergyThreshold.ToString(CultureInfo.InvariantCulture));

                // Sustained energy parameters.
                registryConfig.SetString("SustainedEnergyDbThreshold", config.SustainedEnergyDbThreshold.ToString(CultureInfo.InvariantCulture));
                registryConfig.SetString("SustainedEnergyRequiredDuration", config.SustainedEnergyRequiredDuration.TotalSeconds.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception ex)
            {
                // Handle any errors during saving.
                MessageBox.Show($"Error saving settings: {ex.Message}");
            }
        }


        private void trackBarLowFreq_ValueChanged(object sender, EventArgs e)
        {
            if (!init) return;
            int lowFreq = trackBarLowFreq.Value;
            session.Config.MusicLowFrequency = lowFreq;
            lblLowFreq.Text = $"Low Frequency: {lowFreq} Hz";
        }

        private void trackBarHighFreq_ValueChanged(object sender, EventArgs e)
        {
            if (!init) return;

            int highFreq = trackBarHighFreq.Value;
            session.Config.MusicHighFrequency = highFreq;
            lblHighFreq.Text = $"High Frequency: {highFreq} Hz";
        }

        private void trackBarEnergy_ValueChanged(object sender, EventArgs e)
        {
            if (!init) return;

            // Convert the slider value back to a ratio (0.0 to 1.0).
            double energy = trackBarEnergy.Value / 100.0;
            session.Config.MusicEnergyThreshold = energy;
            lblEnergy.Text = $"Energy Threshold: {trackBarEnergy.Value}%";
        }




        bool init = false;
        private void trackBarThreshold_ValueChanged(object sender, EventArgs e)
        {
            // Get the new threshold value from the slider.
            double newThreshold = trackBarThreshold.Value;

            // Update the session configuration.
            session.Config.SoundThresholdDb = newThreshold;

            // Update the label to display the new threshold.
            lblThresholdValue.Text = $"{newThreshold} dB";

            if (!init) return;
            int newThresholdInt = (int)newThreshold;
            registryConfig.SetInt("AmbientThreshold", newThresholdInt);

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Save settings to the registry when the form is closing.
            closing = true;
            SaveSettings();
        }

        bool closing = false;


        private void initLabell(Label lbl, String msg = "--")
        {
            lbl.Text = msg;
        }

        // When the CheckBox (e.g., chkEnableMusicDetection) changes state:
        private void chkEnableMusicDetection_CheckedChanged(object sender, EventArgs e)
        {
            if (!init) return;
            // Assume 'session' holds your PracticeSession, which contains the config.
            //session.Config.EnableMusicDetection = chkEnableMusicDetection.Checked;
        }


    }
}
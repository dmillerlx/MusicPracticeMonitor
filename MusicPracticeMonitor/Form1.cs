namespace MusicPracticeMonitor
{
    public partial class Form1 : Form
    {
        // The back?end practice session
        private PracticeSession session;

        // A UI timer to periodically update stats on the form.
        private System.Windows.Forms.Timer uiUpdateTimer;

        RegistryConfig regConfig = new RegistryConfig("MusicMonitor");

        public Form1()
        {
            InitializeComponent();

            // Create and configure a new PracticeSessionConfig.
            PracticeSessionConfig config = new PracticeSessionConfig
            {
                // Set any values you want to override the defaults.
                Gain = 1.0,
                SoundThresholdDb = -15.0,
                ActiveStateDelay = TimeSpan.FromSeconds(2),
                IdleStateDelay = TimeSpan.FromSeconds(10)
            };

            // Initialize the practice session with the configuration.
            session = new PracticeSession(config);

            // Setup the UI update timer to tick every 500 milliseconds.
            uiUpdateTimer = new System.Windows.Forms.Timer();
            uiUpdateTimer.Interval = 50; // 500 ms
            uiUpdateTimer.Tick += UiUpdateTimer_Tick;
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
            // Initialize the trackBarThreshold with an appropriate range.
            trackBarThreshold.Minimum = -100; // Silence
            trackBarThreshold.Maximum = 0;    // Maximum loudness
            trackBarThreshold.TickFrequency = 5;

            // Set its initial value to match your current config threshold.
            trackBarThreshold.Value = (int)session.Config.SoundThresholdDb;

            // Update the label to show the current threshold.
            lblThresholdValue.Text = $"{trackBarThreshold.Value} dB";


            initLabell(lblActiveTime);
            initLabell(lblBreakCount);
            initLabell(lblCurrentSoundLevel);
            initLabell(lblIdleTime);
            initLabell(lblPercentActive);
            initLabell(lblSessionState, "");
            initLabell(lblThresholdValue);
            initLabell(lblTotalSessionTime);

            // Retrieve a stored setting, or use a default if not present.
            int ambientThreshold = regConfig.GetInt("AmbientThreshold", -30);
            //numericUpDownThreshold.Value = ambientThreshold;
            trackBarThreshold.Value = ambientThreshold;



            init = true;
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
            regConfig.SetInt("AmbientThreshold", newThresholdInt);



        }

        private void initLabell(Label lbl, String msg = "--")
        {
            lbl.Text = msg;
        }
    }
}
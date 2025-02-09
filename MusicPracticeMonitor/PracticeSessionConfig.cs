using System;
using System.Collections.Generic;

namespace MusicPracticeMonitor
{
    /// <summary>
    /// The configuration class holds all the parameters that the UI can adjust.
    /// </summary>
    public class PracticeSessionConfig
    {
        /// <summary>
        /// A multiplier applied to the raw RMS value. (Default: 1.0)
        /// </summary>
        public double Gain { get; set; }

        /// <summary>
        /// The decibel level (after gain) that qualifies as “sound detected.” 
        /// (For many mic signals, a value like -30 dB may work; adjust as needed.)
        /// </summary>
        public double SoundThresholdDb { get; set; }

        /// <summary>
        /// How long sound must be continuously above the threshold before
        /// the session is considered “active.”
        /// </summary>
        public TimeSpan ActiveStateDelay { get; set; }

        /// <summary>
        /// How long silence (sound below the threshold) must be maintained before
        /// the session is considered “idle” (i.e. a break).
        /// </summary>
        public TimeSpan IdleStateDelay { get; set; }

        public PracticeSessionConfig()
        {
            Gain = 1.0;
            SoundThresholdDb = -30.0;               // Example default threshold in decibels.
            ActiveStateDelay = TimeSpan.FromSeconds(2);  // 2 seconds of continuous sound to switch to Active.
            IdleStateDelay = TimeSpan.FromSeconds(10);   // 10 seconds of continuous silence to switch to Idle.
        }
    }
}

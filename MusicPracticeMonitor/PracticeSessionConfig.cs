using System;

namespace MusicPracticeMonitor
{
    public enum DetectionMode
    {
        Normal,
        FrequencyFilter,
        SustainedEnergy,
        Combined
    }

    public class PracticeSessionConfig
    {
        // General parameters:
        public double Gain { get; set; } = 1.0;
        public double SoundThresholdDb { get; set; } = -30.0;
        public TimeSpan ActiveStateDelay { get; set; } = TimeSpan.FromSeconds(2);
        public TimeSpan IdleStateDelay { get; set; } = TimeSpan.FromSeconds(10);

        // Detection mode selection:
        public DetectionMode CurrentDetectionMode { get; set; } = DetectionMode.Normal;

        // Frequency Filter parameters:
        public double MusicLowFrequency { get; set; } = 100.0;
        public double MusicHighFrequency { get; set; } = 4000.0;
        public double MusicEnergyThreshold { get; set; } = 0.5;

        // Sustained Energy parameters:
        // The decibel threshold that must be exceeded.
        public double SustainedEnergyDbThreshold { get; set; } = -30.0;
        // The time duration that the level must be sustained.
        public TimeSpan SustainedEnergyRequiredDuration { get; set; } = TimeSpan.FromSeconds(2);
    }
}

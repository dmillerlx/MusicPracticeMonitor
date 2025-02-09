namespace MusicPracticeMonitor
{
    /// <summary>
    /// Custom EventArgs for delivering sound level data.
    /// </summary>
    public class SoundLevelEventArgs : EventArgs
    {
        /// <summary>
        /// The computed decibel level.
        /// </summary>
        public double Decibels { get; set; }
        public DateTime Timestamp { get; set; }
    }
}

namespace MusicPracticeMonitor
{
    /// <summary>
    /// A container class to hold the current statistics. The UI can poll these at any time.
    /// </summary>
    public class PracticeSessionStats
    {
        public TimeSpan TotalSessionTime { get; set; }
        public TimeSpan TotalActiveTime { get; set; }
        public TimeSpan TotalIdleTime { get; set; }
        public double PercentActive { get; set; }
        public int BreakCount { get; set; }
        public List<TimeSpan> BreakDurations { get; set; }
        public AudioState CurrentAudioState { get; set; }
        public SessionStatus SessionStatus { get; set; }
        public double CurrentSoundLevel { get; set; }
    }
}

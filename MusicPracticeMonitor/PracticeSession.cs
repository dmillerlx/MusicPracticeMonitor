using System.Timers;

namespace MusicPracticeMonitor
{
    /// <summary>
    /// This class encapsulates the music practice session logic.
    /// It handles the mic listening, state transitions (active vs idle),
    /// and timer-based accumulation of practice statistics.
    /// </summary>
    public class PracticeSession
    {
        private readonly PracticeSessionConfig config;
        private SessionStatus sessionStatus;
        private AudioState currentAudioState;

        // Time accumulators.
        private TimeSpan totalSessionTime;
        private TimeSpan totalActiveTime;
        private TimeSpan totalIdleTime;

        // For timer-delta calculations.
        private DateTime lastTimerTick;
        private readonly System.Timers.Timer updateTimer;

        // For break tracking.
        private readonly List<TimeSpan> breakDurations;
        private DateTime? idlePeriodStart; // When the user went idle (beginning a break)

        // For audio state transitions.
        private DateTime? activeTransitionStart;
        private DateTime? idleTransitionStart;

        // The mic monitor instance.
        private readonly MicMonitor micMonitor;

        // A simple lock object to synchronize access.
        private readonly object lockObj = new object();
        private double currentDecibels = -100.0; // Default to a very low value when silent

        //private readonly PracticeSessionConfig config;

        public PracticeSessionConfig Config => config;

        public PracticeSession(PracticeSessionConfig configVal)
        {
            this.config = configVal;
            sessionStatus = SessionStatus.NotStarted;
            currentAudioState = AudioState.Idle; // Start in Idle mode.
            totalSessionTime = TimeSpan.Zero;
            totalActiveTime = TimeSpan.Zero;
            totalIdleTime = TimeSpan.Zero;
            breakDurations = new List<TimeSpan>();

            // Set up the update timer (e.g. 100 ms tick).
            updateTimer = new System.Timers.Timer(100);
            updateTimer.Elapsed += UpdateTimer_Elapsed;
            updateTimer.AutoReset = true;

            // Set up the mic monitor.
            micMonitor = new MicMonitor(config);
            micMonitor.SoundLevelAvailable += OnSoundLevelAvailable;

        }

        /// <summary>
        /// Returns the current session status.
        /// </summary>
        public SessionStatus CurrentSessionStatus => sessionStatus;

        /// <summary>
        /// Starts a new session (or restarts a session if one was reset).
        /// </summary>
        public void Start()
        {
            if (sessionStatus == SessionStatus.Running)
                return;

            lock (lockObj)
            {
                totalSessionTime = TimeSpan.Zero;
                totalActiveTime = TimeSpan.Zero;
                totalIdleTime = TimeSpan.Zero;
                breakDurations.Clear();
                currentAudioState = AudioState.Idle;
                activeTransitionStart = null;
                idleTransitionStart = null;
                idlePeriodStart = null;
                lastTimerTick = DateTime.Now;
                sessionStatus = SessionStatus.Running;
            }

            micMonitor.Start();
            updateTimer.Start();
        }

        /// <summary>
        /// Stops the session. (No further statistics are collected.)
        /// </summary>
        public void Stop()
        {
            if (sessionStatus != SessionStatus.Running && sessionStatus != SessionStatus.Paused)
                return;

            lock (lockObj)
            {
                sessionStatus = SessionStatus.Stopped;
            }

            updateTimer.Stop();
            micMonitor.Stop();
        }

        /// <summary>
        /// Pauses the session (stops mic and timer, but keeps the counters).
        /// </summary>
        public void Pause()
        {
            if (sessionStatus != SessionStatus.Running)
                return;

            lock (lockObj)
            {
                sessionStatus = SessionStatus.Paused;
            }

            updateTimer.Stop();
            micMonitor.Stop();
        }

        /// <summary>
        /// Resumes a paused session.
        /// </summary>
        public void Resume()
        {
            if (sessionStatus != SessionStatus.Paused)
                return;

            lock (lockObj)
            {
                sessionStatus = SessionStatus.Running;
                lastTimerTick = DateTime.Now;
            }

            micMonitor.Start();
            updateTimer.Start();
        }

        /// <summary>
        /// Resets the session, clearing all accumulated counters.
        /// </summary>
        public void Reset()
        {
            Stop();

            lock (lockObj)
            {
                sessionStatus = SessionStatus.NotStarted;
                totalSessionTime = TimeSpan.Zero;
                totalActiveTime = TimeSpan.Zero;
                totalIdleTime = TimeSpan.Zero;
                breakDurations.Clear();
                activeTransitionStart = null;
                idleTransitionStart = null;
                idlePeriodStart = null;
                currentAudioState = AudioState.Idle;
            }
        }

        /// <summary>
        /// Returns a snapshot of the current session statistics.
        /// </summary>
        public PracticeSessionStats GetStats()
        {
            lock (lockObj)
            {
                double percentActive = totalSessionTime.TotalSeconds > 0
                    ? (totalActiveTime.TotalSeconds / totalSessionTime.TotalSeconds * 100.0)
                    : 0.0;

                return new PracticeSessionStats
                {
                    TotalSessionTime = totalSessionTime,
                    TotalActiveTime = totalActiveTime,
                    TotalIdleTime = totalIdleTime,
                    PercentActive = percentActive,
                    BreakCount = breakDurations.Count,
                    BreakDurations = new List<TimeSpan>(breakDurations),
                    CurrentAudioState = currentAudioState,
                    SessionStatus = sessionStatus,
                    CurrentSoundLevel = currentDecibels // New property exposed to the UI.
                };
            }
        }

        /// <summary>
        /// The update timer ticks every 100 ms (or as configured) and adds the elapsed time
        /// to either the active or idle accumulator based on the current mic state.
        /// </summary>
        private void UpdateTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            lock (lockObj)
            {
                if (sessionStatus != SessionStatus.Running)
                    return;

                DateTime now = DateTime.Now;
                TimeSpan delta = now - lastTimerTick;
                totalSessionTime += delta;

                // Accumulate time based on the current audio state.
                if (currentAudioState == AudioState.Active)
                    totalActiveTime += delta;
                else
                    totalIdleTime += delta;

                lastTimerTick = now;
            }
        }

        /// <summary>
        /// Handles the sound level events coming from the microphone.
        /// This method implements a simple state machine:
        /// - If the decibel reading is above the configured threshold, then (after ActiveStateDelay)
        ///   switch from Idle to Active.
        /// - If the decibel reading falls below the threshold (silence) for IdleStateDelay,
        ///   switch from Active to Idle and mark a break.
        /// </summary>
        private void OnSoundLevelAvailable(object sender, SoundLevelEventArgs e)
        {
            lock (lockObj)
            {
                // Update the current sound level property.
                currentDecibels = e.Decibels;

                if (sessionStatus != SessionStatus.Running)
                    return;

                // Determine whether the reading qualifies as “sound detected.”
                bool isSoundDetected = e.Decibels >= config.SoundThresholdDb;

                if (isSoundDetected)
                {
                    // Clear any pending idle transition.
                    idleTransitionStart = null;

                    if (currentAudioState == AudioState.Idle)
                    {
                        // Start or continue timing the potential switch to Active.
                        if (activeTransitionStart == null)
                        {
                            activeTransitionStart = e.Timestamp;
                        }
                        else if ((e.Timestamp - activeTransitionStart.Value) >= config.ActiveStateDelay)
                        {
                            // Transition to Active after the delay.
                            currentAudioState = AudioState.Active;

                            // If a break (idle period) was in progress, record its duration.
                            if (idlePeriodStart.HasValue)
                            {
                                TimeSpan breakDuration = e.Timestamp - idlePeriodStart.Value;
                                breakDurations.Add(breakDuration);
                                idlePeriodStart = null;
                            }
                            activeTransitionStart = null;
                        }
                    }
                    // If already active, no further action is needed.
                }
                else // No sufficient sound detected (silence)
                {
                    activeTransitionStart = null;

                    if (currentAudioState == AudioState.Active)
                    {
                        // Begin or continue timing the potential switch to Idle.
                        if (idleTransitionStart == null)
                        {
                            idleTransitionStart = e.Timestamp;
                        }
                        else if ((e.Timestamp - idleTransitionStart.Value) >= config.IdleStateDelay)
                        {
                            // Transition to Idle after the configured delay.
                            currentAudioState = AudioState.Idle;
                            // Mark the beginning of a break period.
                            idlePeriodStart = e.Timestamp;
                            idleTransitionStart = null;
                        }
                    }
                    // If already idle, nothing changes.
                }
            }
        }
    }
}

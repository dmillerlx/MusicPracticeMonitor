using NAudio.Wave;

namespace MusicPracticeMonitor
{
    /// <summary>
    /// The MicMonitor listens to the microphone and raises events with the current sound level.
    /// It uses NAudio’s WaveInEvent to capture audio data.
    /// </summary>
    public class MicMonitor
    {
        private readonly WaveInEvent waveIn;
        private readonly PracticeSessionConfig config;

        /// <summary>
        /// Raised every time a new sound level is computed.
        /// </summary>
        public event EventHandler<SoundLevelEventArgs> SoundLevelAvailable;

        public MicMonitor(PracticeSessionConfig config)
        {
            this.config = config;
            // Set up a WaveInEvent for a typical format (mono, 16-bit, 44.1 kHz).
            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 1)
            };
            waveIn.DataAvailable += OnDataAvailable;
        }

        /// <summary>
        /// Starts capturing audio.
        /// </summary>
        public void Start()
        {
            waveIn.StartRecording();
        }

        /// <summary>
        /// Stops capturing audio.
        /// </summary>
        public void Stop()
        {
            waveIn.StopRecording();
        }

        /// <summary>
        /// Called by NAudio when audio data is available.
        /// This method computes the RMS value of the audio buffer, applies gain,
        /// converts it to decibels, and then raises the SoundLevelAvailable event.
        /// </summary>
        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            int bytesPerSample = 2; // 16-bit audio
            int sampleCount = e.BytesRecorded / bytesPerSample;
            if (sampleCount == 0)
                return;

            double sumSquares = 0;
            for (int i = 0; i < e.BytesRecorded; i += bytesPerSample)
            {
                // Convert two bytes to a 16-bit signed sample.
                short sample = BitConverter.ToInt16(e.Buffer, i);
                // Normalize sample to range [-1.0, 1.0].
                double sample32 = sample / 32768.0;
                sumSquares += sample32 * sample32;
            }
            double rms = Math.Sqrt(sumSquares / sampleCount);

            // Apply gain.
            double effectiveRms = rms * config.Gain;

            // Convert the RMS value to decibels.
            double decibels = effectiveRms > 0 ? 20 * Math.Log10(effectiveRms) : -100; // If silent, assign a low value.

            // Create the event args with the current timestamp.
            SoundLevelEventArgs args = new SoundLevelEventArgs
            {
                Decibels = decibels,
                Timestamp = DateTime.Now
            };

            // Raise the event.
            SoundLevelAvailable?.Invoke(this, args);
        }
    }
}

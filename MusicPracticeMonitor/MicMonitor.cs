using System;
using System.Numerics; // For Complex numbers.
using MathNet.Numerics.IntegralTransforms;
using NAudio.Wave;

namespace MusicPracticeMonitor
{
    public class MicMonitor
    {
        private readonly WaveInEvent waveIn;
        private readonly PracticeSessionConfig config;

        /// <summary>
        /// Event raised whenever a new sound level is computed.
        /// </summary>
        public event EventHandler<SoundLevelEventArgs> SoundLevelAvailable;

        /// <summary>
        /// The last computed energy ratio from the music detection analysis.
        /// </summary>
        public double LastMusicRatio { get; private set; } = 0;

        public MicMonitor(PracticeSessionConfig config)
        {
            this.config = config;
            waveIn = new WaveInEvent
            {
                WaveFormat = new WaveFormat(44100, 16, 1)
            };
            waveIn.DataAvailable += OnDataAvailable;
        }

        public void Start() => waveIn.StartRecording();
        public void Stop() => waveIn.StopRecording();

        private void OnDataAvailable(object sender, WaveInEventArgs e)
        {
            int bytesPerSample = 2; // 16-bit audio.
            int sampleCount = e.BytesRecorded / bytesPerSample;
            if (sampleCount == 0)
                return;

            double sumSquares = 0;
            float[] samples = new float[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                short sample = BitConverter.ToInt16(e.Buffer, i * bytesPerSample);
                float sample32 = sample / 32768f;
                samples[i] = sample32;
                sumSquares += sample32 * sample32;
            }
            double rms = Math.Sqrt(sumSquares / sampleCount);
            double effectiveRms = rms * config.Gain;
            double decibels = effectiveRms > 0 ? 20 * Math.Log10(effectiveRms) : -100;

            // Apply music detection filtering only if enabled.
            if (config.EnableMusicDetection)
            {
                // The IsMusic method will update LastMusicRatio.
                if (!IsMusic(samples, waveIn.WaveFormat))
                {
                    decibels = -100; // Force as silence/ambient noise.
                }
            }

            SoundLevelEventArgs args = new SoundLevelEventArgs
            {
                Decibels = decibels,
                Timestamp = DateTime.Now
            };

            SoundLevelAvailable?.Invoke(this, args);
        }

        /// <summary>
        /// Performs FFT analysis to determine if the input is music-like.
        /// It computes the ratio of energy in the configurable frequency band versus total energy.
        /// The computed ratio is saved in LastMusicRatio.
        /// </summary>
        /// <param name="samples">Normalized audio samples.</param>
        /// <param name="format">Audio format (to get sample rate).</param>
        /// <returns>True if the ratio exceeds the MusicEnergyThreshold; otherwise, false.</returns>
        private bool IsMusic(float[] samples, WaveFormat format)
        {
            int sampleCount = samples.Length;
            // Prepare FFT input.
            Complex[] fftBuffer = new Complex[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                fftBuffer[i] = new Complex(samples[i], 0);
            }

            // Perform FFT.
            Fourier.Forward(fftBuffer, FourierOptions.Matlab);

            double sampleRate = format.SampleRate;
            double freqResolution = sampleRate / sampleCount;
            // Use configurable frequency band values.
            double lowFreq = config.MusicLowFrequency;
            double highFreq = config.MusicHighFrequency;

            double energyInBand = 0;
            double totalEnergy = 0;
            int halfCount = sampleCount / 2; // Consider only positive frequencies.

            for (int i = 0; i < halfCount; i++)
            {
                double frequency = i * freqResolution;
                double magnitude = fftBuffer[i].Magnitude;
                totalEnergy += magnitude;
                if (frequency >= lowFreq && frequency <= highFreq)
                {
                    energyInBand += magnitude;
                }
            }

            double ratio = totalEnergy > 0 ? energyInBand / totalEnergy : 0;
            LastMusicRatio = ratio;
            return ratio > config.MusicEnergyThreshold;
        }
    }
}

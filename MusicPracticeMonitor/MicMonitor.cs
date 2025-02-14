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

        // For Sustained Energy (and Combined mode).
        private DateTime? sustainedEnergyStart = null;

        public event EventHandler<SoundLevelEventArgs> SoundLevelAvailable;

        /// <summary>
        /// Exposes the last computed energy ratio from the FFT analysis (for frequency filter modes).
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
                float sampleFloat = sample / 32768f;
                samples[i] = sampleFloat;
                sumSquares += sampleFloat * sampleFloat;
            }
            double rms = Math.Sqrt(sumSquares / sampleCount);
            double effectiveRms = rms * config.Gain;
            double decibels = effectiveRms > 0 ? 20 * Math.Log10(effectiveRms) : -100;

            // Switch based on the selected detection mode.
            switch (config.CurrentDetectionMode)
            {
                case DetectionMode.Normal:
                    // Use the computed decibels as-is.
                    break;

                case DetectionMode.FrequencyFilter:
                    if (!IsMusic(samples, waveIn.WaveFormat))
                    {
                        decibels = -100;
                    }
                    break;

                case DetectionMode.SustainedEnergy:
                    if (decibels >= config.SustainedEnergyDbThreshold)
                    {
                        if (sustainedEnergyStart == null)
                        {
                            sustainedEnergyStart = DateTime.Now;
                        }
                        else if ((DateTime.Now - sustainedEnergyStart) >= config.SustainedEnergyRequiredDuration)
                        {
                            // Sustained high energy: leave decibels as computed.
                        }
                    }
                    else
                    {
                        sustainedEnergyStart = null;
                        decibels = -100;
                    }
                    break;

                case DetectionMode.Combined:
                    // First, check for sustained energy.
                    if (decibels >= config.SustainedEnergyDbThreshold)
                    {
                        if (sustainedEnergyStart == null)
                        {
                            sustainedEnergyStart = DateTime.Now;
                        }
                        else if ((DateTime.Now - sustainedEnergyStart) >= config.SustainedEnergyRequiredDuration)
                        {
                            // Then, check frequency filter.
                            if (!IsMusic(samples, waveIn.WaveFormat))
                            {
                                decibels = -100;
                            }
                        }
                    }
                    else
                    {
                        sustainedEnergyStart = null;
                        decibels = -100;
                    }
                    break;
            }

            var args = new SoundLevelEventArgs
            {
                Decibels = decibels,
                Timestamp = DateTime.Now
            };

            SoundLevelAvailable?.Invoke(this, args);
        }

        /// <summary>
        /// Performs FFT analysis to compute the ratio of energy in the target frequency band.
        /// Updates LastMusicRatio and returns true if the ratio exceeds the configured threshold.
        /// </summary>
        private bool IsMusic(float[] samples, WaveFormat format)
        {
            int sampleCount = samples.Length;
            Complex[] fftBuffer = new Complex[sampleCount];
            for (int i = 0; i < sampleCount; i++)
            {
                fftBuffer[i] = new Complex(samples[i], 0);
            }
            Fourier.Forward(fftBuffer, FourierOptions.Matlab);

            double sampleRate = format.SampleRate;
            double freqResolution = sampleRate / sampleCount;

            double lowFreq = config.MusicLowFrequency;
            double highFreq = config.MusicHighFrequency;
            double energyInBand = 0;
            double totalEnergy = 0;

            int halfCount = sampleCount / 2; // Only positive frequencies.
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

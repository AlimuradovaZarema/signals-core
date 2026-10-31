using System;

namespace SignalProcessing.Core 
{
    internal class SignalProcessingCoreRangeAnalyzer
    {
        private float min;
        private float max;
        private int minDuration;

        public event EventHandler<OutOfRangeEventArgs> OutOfRangeDetected;

        public SignalProcessingCoreRangeAnalyzer(float min, float max, int minDurationSamples)
        {
            this.min = min;
            this.max = max;
            this.minDuration = minDurationSamples;
        }

        public void Analyze(float[] data)
        {
            int i = 0;
            while (i < data.Length)
            {
                if (data[i] < min || data[i] > max)
                {
                    int start = i;
                    while (i < data.Length && (data[i] < min || data[i] > max))
                        i++;
                    int end = i - 1;

                    if (end - start + 1 >= minDuration)
                        OutOfRangeDetected?.Invoke(this,
                            new OutOfRangeEventArgs(start, end));
                }
                else
                {
                    i++;
                }
            }
        }
    }
}
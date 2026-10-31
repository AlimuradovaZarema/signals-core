using System;
using System.Collections.Generic;

namespace SignalProcessing.Core
{
    internal class Tools
    {
        public static SignalProcessingCore Line(float len, float freq, float k, float b)
        {
            int count = (int)(len * freq + 0.5);
            float[] y = new float[count];
            for (int i = 0; i < count; i++)
            {
                float t = i / freq;
                y[i] = k * t + b;
            }
            return new SignalProcessingCore(freq, y);
        }

        public static SignalProcessingCore Sin(float len, float freq, float period, float phase, float scale)
        {
            int count = (int)(len * freq + 0.5);
            float[] y = new float[count];
            float diff = 1 / freq;
            for (int i = 0; i < count; i++)
            {
                float t = i * diff;
                y[i] = scale * (float)Math.Sin((t - phase) * 2 * Math.PI / period);
            }
            return new SignalProcessingCore(freq, y);
        }

        public static SignalProcessingCore Noise(float len, float freq, float R)
        {
            Random random = new Random();
            int count = (int)(len * freq + 0.5);
            float[] y = new float[count];
            for (int i = 0; i < count; i++)
            {
                y[i] = (float)(random.NextDouble() * 2 * R - R);
            }
            return new SignalProcessingCore(freq, y);
        }

        public static SignalProcessingCore Summ(List<SignalProcessingCore> signals)
        {
            float freq = signals[0].Freq;
            int minLen = signals[0].Value.Length;
            for (int i = 1; i < signals.Count; i++)
                if (signals[i].Value.Length < minLen)
                    minLen = signals[i].Value.Length;

            float[] result = new float[minLen];
            for (int i = 0; i < minLen; i++)
            {
                float sum = 0;
                for (int j = 0; j < signals.Count; j++)
                    sum += signals[j].Value[i];
                result[i] = sum;
            }
            return new SignalProcessingCore(freq, result);
        }

        public static SignalProcessingCore Skley(List<SignalProcessingCore> signals)
        {
            float freq = signals[0].Freq;
            int totalLen = 0;
            for (int i = 0; i < signals.Count; i++)
                totalLen += signals[i].Value.Length;

            float[] result = new float[totalLen];
            int pos = 0;
            for (int i = 0; i < signals.Count; i++)
            {
                Array.Copy(signals[i].Value, 0, result, pos, signals[i].Value.Length);
                pos += signals[i].Value.Length;
            }
            return new SignalProcessingCore(freq, result);
        }
    }
}
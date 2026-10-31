using System;

namespace SignalProcessing.Core
{
    internal static class OfflineFilter
    {
        public static float[] Filter(float[] data, int windowSize)
        {
            int M = (windowSize - 1) / 2;

            float[] extended = new float[data.Length + 2 * M];
            for (int i = 0; i < M; i++)
                extended[i] = data[0];
            Array.Copy(data, 0, extended, M, data.Length);
            for (int i = 0; i < M; i++)
                extended[M + data.Length + i] = data[data.Length - 1];

            float[] result = new float[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                float sum = 0;
                for (int j = i; j < i + windowSize; j++)
                    sum += extended[j];
                result[i] = sum / windowSize;
            }
            return result;
        }
    }
}
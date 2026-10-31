using System.Collections.Generic;

namespace SignalProcessing.Core
{
    internal class OnlineFilter
    {
        private int windowSize;
        private Queue<float> buffer;

        public OnlineFilter(int windowSize)
        {
            this.windowSize = windowSize;
            buffer = new Queue<float>();
        }

        public float[] Filter(float[] data)
        {
            float[] result = new float[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                buffer.Enqueue(data[i]);
                if (buffer.Count > windowSize)
                    buffer.Dequeue();

                float sum = 0;
                foreach (float v in buffer)
                    sum += v;
                result[i] = sum / windowSize;
            }
            return result;
        }
    }
}
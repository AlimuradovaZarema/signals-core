using System.Collections.Generic;
using System.IO;

namespace SignalProcessing.Core
{
    public class SingleChannelSignalReader
    {
        static public SingleChannelSignal SignalReader(string filePath)
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                float freq = float.Parse(reader.ReadLine());
                List<float> Signal = new List<float>();
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;
                    Signal.Add(float.Parse(line));
                }
                float[] arrSignal = Signal.ToArray();
                SingleChannelSignal data = new SingleChannelSignal(freq, arrSignal);
                return data;
            }
        }
    }
}
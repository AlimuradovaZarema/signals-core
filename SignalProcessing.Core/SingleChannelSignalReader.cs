using System.Collections.Generic;
using System.IO;

namespace SignalProcessing.Core
{
    internal class SingleChannelSignalReader
    {
        static public SignalProcessingCore SignalReader(string filePath)
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
                SignalProcessingCore data = new SignalProcessingCore(freq, arrSignal);
                return data;
            }
        }
    }
}
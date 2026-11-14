using System.IO;

namespace SignalProcessing.Core
{
    public class SingleChannelSignalWriter
    {
        static public void SignalWriter(SingleChannelSignal obj, string filepath)
        {
            using (StreamWriter writer = new StreamWriter(filepath))
            {
                writer.WriteLine(obj.Freq);
                foreach (float el in obj.Value)
                {
                    writer.WriteLine(el);
                }
            }
        }
    }
}
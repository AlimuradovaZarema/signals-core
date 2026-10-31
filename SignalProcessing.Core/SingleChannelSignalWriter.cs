using System.IO;

namespace SignalProcessing.Core
{
    internal class SignalProcessingCoreWriter
    {
        static public void SignalWriter(SignalProcessingCore obj, string filepath)
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
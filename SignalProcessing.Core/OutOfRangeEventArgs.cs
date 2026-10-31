using System;

namespace SignalProcessing.Core
{
    internal class OutOfRangeEventArgs : EventArgs
    {
        public int StartIndex { get; }
        public int EndIndex { get; }

        public OutOfRangeEventArgs(int startIndex, int endIndex)
        {
            StartIndex = startIndex;
            EndIndex = endIndex;
        }
    }
}
using System;

namespace WordSwap
{
    class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}

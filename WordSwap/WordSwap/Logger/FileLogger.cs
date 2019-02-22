using System;
using System.IO;

namespace WordSwap
{
    class FileLogger : ILogger
    {
        public void Clear()
        {
            Console.Clear();
        }

        public void Log(string message)
        {
            Console.WriteLine("=============Error====================");
            Console.WriteLine("Error Message: " + message);
            Console.WriteLine("======================================");

            string directory = Directory.GetCurrentDirectory();
            string strPath = $"{ directory }\\log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + message);
                sw.WriteLine("===========End=============== " + DateTime.Now);
                sw.WriteLine();
            }
        }
    }
}

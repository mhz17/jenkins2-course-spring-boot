using System;
using System.Threading;

namespace WordSwap
{
    class Program
    {

        static void Main(string[] args)
        {

            ILogger logger = new ConsoleLogger();
            ILogger errorLogger = new FileLogger();

            var dictionary = new WordDictionary(errorLogger);
            var word = new Word(dictionary, logger, errorLogger);
            var keepPlaying = false;

            if (dictionary.LoadDictionary()) {
                do
                {
                    word.PlayGame();

                    logger.Log("");
                    logger.Log("Start Again? Y or Exit");

                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        keepPlaying = true;
                    }
                    else
                    {
                        keepPlaying = false;
                    }
                    logger.Clear();

                } while (keepPlaying);

                logger.Log("");
                logger.Log("*** Goodbye ***");
                Thread.Sleep(2000);
            };

        }

    }
}

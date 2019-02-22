using System.Collections.Generic;
using System.IO;

namespace WordSwap
{
    class WordDictionary: IWordDictionary
    {

        public List<string> listOfWords;
        ILogger _logger;

        public WordDictionary(ILogger logger)
        {
            _logger = logger;
        }

        public bool CheckIfWordExsits(string word)
        {
            if (!listOfWords.Contains(word))
            {
                return false;
            }

            return true;
        }

        public bool LoadDictionary()
        {
            try
            {
                listOfWords = new List<string>
                {
                    "spin",
                    "span",
                    "spit",
                    "sput",
                    "spun",
                    "spot"
                };
            }
            catch
            {
                _logger.Log("Dictionary file not found, press ESC to exit application");
                return false;
            }

            return true; ;
          
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace WordSwap
{
    class Word
    {
        ILogger _logger;
        ILogger _errorLogger;
        IWordDictionary _dictionary;
        public string _firstWord;
        public string _lastWord;

        public Word(IWordDictionary dictionary, ILogger logger, ILogger errorLogger)
        {
            _logger = logger;
            _errorLogger = errorLogger;
            _dictionary = dictionary;
        }

        public void PlayGame()
        {

            _logger.Log("---------------------------");
            _logger.Log("WELCOME TO WORD SWAP PUZZLE");
            _logger.Log("");

            _logger.Log("== Provide first word ==");
            _firstWord = ProvideWord();
            _logger.Log("");

            _logger.Log("== Provide last word ==");
            _lastWord = ProvideWord();
            _logger.Log("");

            _logger.Log("-----------WORDS-----------");
            _logger.Log("First Word: " + _firstWord);
            _logger.Log("Last Word:  " + _lastWord);
            _logger.Log("---------------------------");
            _logger.Log("");

            _logger.Log("-----------RESULT----------");
            GetResult();
            _logger.Log("---------------------------");

        }

        public string ProvideWord()
        {
            while (true)
            {
                var word = Console.ReadLine();
                if (string.IsNullOrEmpty(word))
                {

                    _logger.Log("");
                    _logger.Log($" !!! Please provide 4 character word !!! ");
                    _logger.Log("");
                    _logger.Log($"== Provide another word ==");
                    continue;

                } else if (!_dictionary.CheckIfWordExsits(word))
                {

                    _logger.Log("");
                    _logger.Log($" !!! Word : {word} does not exist in supplied dictionary !!! ");
                    _logger.Log("");
                    _logger.Log($"== Provide another word ==");
                    continue;

                }

                return word;

            }
        }
         
        public void GetResult()
        {
            if (_firstWord == _lastWord)
            {
                _logger.Log("- > First and Last Word are the same < -");
            }
            else
            {
                var newList = new List<string>();
                var currentWord = _firstWord;
                newList.Add(currentWord);

                while (true)
                {
                    currentWord = ReplaceLetter(currentWord, newList);
                    newList.Add(currentWord);
                    if (currentWord == _lastWord)
                    {
                        break;
                    }
                }
 
                foreach (var word in newList)
                {
                    _logger.Log($" -> { word } ");
                }
            }
        }

        public string ReplaceLetter(string currentWord, List<string> listOfAddedWords)
        {
            string newWord = currentWord;
            var dict = FindFirstDifference(currentWord);
            var newWordCharList = newWord.ToCharArray();

            for (char c = 'a'; c <= 'z'; c++)
            {
               if (c != dict.Value)
                {
                    newWordCharList[dict.Key] = c;
                    newWord = new string(newWordCharList);
                    if (_dictionary.CheckIfWordExsits(newWord) &&
                        !listOfAddedWords.Contains(newWord))
                    {
                        return newWord;
                    }
                }
            }
            return null;
        }

        public KeyValuePair<int, char> FindFirstDifference(string currentWord)
        {
            var lastWord = _lastWord;
            var currentWordArray = currentWord.ToCharArray();
            var lastWordArray = lastWord.ToCharArray();
            var i = 0;

            do
            {
                if (currentWordArray[i] != lastWordArray[i])
                {
                    return new KeyValuePair<int, char>(i, currentWordArray[i]);
                }
                i += 1;
            } while (i < 4);

            return new KeyValuePair<int, char>();
        }

    }
}

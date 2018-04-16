using Demo1_Words.Core.Interface;

namespace Demo1_Words.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Linq;
    public class WordOperator : IWordOperator
    {
        private List<string> allWords;
        private Dictionary<int, int> rangeDictionary;
        public WordOperator()
        {
            allWords = File.ReadAllLines("legitWords.txt").ToList();
            rangeDictionary = new Dictionary<int, int>
            {
                {2,0},
                {3,WordIndexConstants.RANGE_OF_WORD_OF_3CHARACTERS},
                {4,WordIndexConstants.RANGE_OF_WORD_OF_4CHARACTERS},
                {5,WordIndexConstants.RANGE_OF_WORD_OF_5CHARACTERS},
                {6,WordIndexConstants.RANGE_OF_WORD_OF_6CHARACTERS},
                {7,WordIndexConstants.RANGE_OF_WORD_OF_7CHARACTERS},
                {8,WordIndexConstants.RANGE_OF_WORD_OF_8CHARACTERS},
                {9,WordIndexConstants.RANGE_OF_WORD_OF_9CHARACTERS},
                {10,WordIndexConstants.RANGE_OF_WORD_OF_10CHARACTERS},
                {11,WordIndexConstants.RANGE_OF_WORD_OF_10_PLUS_CHARACTERS}
            };
        }
        public bool AtemptValidation(string alphabet, string atempt)
        {
            if (alphabet.Length < atempt.Length || atempt == String.Empty || !(Regex.IsMatch(atempt, @"^[a-zA-Z]+$")))
            {
                return false;
            }
            char[] alphabetArray = new char[26];
            char[] atemtArray = new char[26];
            for (int j = 0; j < alphabet.Length; j++)
            {
                alphabetArray[alphabet[j] - 'a']++;
                if (j < atempt.Length)
                {
                    atemtArray[atempt[j] - 'a']++;
                }
            }
            for (int j = 0; j <= 25; j++)
            {
                if (alphabetArray[j] < atemtArray[j])
                {
                    return  false;
                }
            }
            return true;
        }
        public bool SolverValidation(string characters)
        {
            if (characters == String.Empty || characters.Length < 3)
            {
                Console.WriteLine("Please enter at least 3 letters.");
                return false;
            }
            if(!(Regex.IsMatch(characters, @"^[a-zA-Z]+$")))
            {
                Console.WriteLine("The resolver works only with letters.");
                return false;
            }
            return true;
        }
        public string Shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                char value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public List<string> FindingSoutions(string characters)
        {
            int length;
            if (characters.Length > 11)
            {
                length = 11;
            }
            else
            {
                length = characters.Length;
            }
            int range = rangeDictionary[length];
            List<string> validWords = new List<string>();
            int[] alphabetArray = new int[26];
            for (int i = 0; i < characters.Length; i++)
            {
                alphabetArray[characters[i] - 'a']++;
            }
            for (int i = 0; i < range; i++)
            {
                bool isValid = true;
                string currentWord = allWords[i];
                int[] temporaryArray = new int[26];
                for (int j = 0; j < currentWord.Length; j++)
                {
                    temporaryArray[currentWord[j] - 'a']++;
                }
                for (int j = 0; j <= 25; j++)
                {
                    if (alphabetArray[j] < temporaryArray[j])
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    validWords.Add(currentWord);
                }
            }
            if (validWords.Count == 0)
            {
                Console.WriteLine("No valid word");
            }
            return validWords;
        }
        public string GivingRandomWordWithNLenght(int n)
        {
            Random r = new Random();
            int randomIndex = r.Next(rangeDictionary[n-1],rangeDictionary[n]);
            return allWords[randomIndex];
        }
    }
}
using System.Text.RegularExpressions;

namespace Demo1_Words.Core
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class wordOperator
    {
        private static List<string> allWords = File.ReadAllLines("legitWords.txt").ToList();

        public wordOperator()
        {
            
        }

        public static bool atemptValidation(string alphabet, string atempt)
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
        public static string shuffle(string str)
        {
            char[] array = str.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                var value = array[k];
                array[k] = array[n];
                array[n] = value;
            }
            return new string(array);
        }
        public static List<string> findingSoution(string characters)
        {
            int range;
            switch (characters.Length)
            {
                case 3:
                    range = Constants.RANGE_OF_WORD_OF_3CHARACTERS;
                    break;
                case 4:
                    range = Constants.RANGE_OF_WORD_OF_4CHARACTERS;
                    break;
                case 5:
                    range = Constants.RANGE_OF_WORD_OF_5CHARACTERS;
                    break;
                case 6:
                    range = Constants.RANGE_OF_WORD_OF_6CHARACTERS;
                    break;
                case 7:
                    range = Constants.RANGE_OF_WORD_OF_7CHARACTERS;
                    break;
                case 8:
                    range = Constants.RANGE_OF_WORD_OF_8CHARACTERS;
                    break;
                case 9:
                    range = Constants.RANGE_OF_WORD_OF_9CHARACTERS;
                    break;
                case 10:
                    range = Constants.RANGE_OF_WORD_OF_10CHARACTERS;
                    break;
                default:
                    range = Constants.RANGE_OF_WORD_OF_10_PLUS_CHARACTERS;
                    break;
            }
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

        public static string givingRandomWordWithNLenght(int n)
        {
            Random r = new Random();
            int randomIndex = r.Next();
            switch (n)
            {
                case 3:
                    randomIndex = r.Next(0, Constants.RANGE_OF_WORD_OF_3CHARACTERS);
                    break;
                case 4:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_3CHARACTERS, Constants.RANGE_OF_WORD_OF_4CHARACTERS);
                    break;
                case 5:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_4CHARACTERS, Constants.RANGE_OF_WORD_OF_5CHARACTERS);
                    break;
                case 6:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_5CHARACTERS, Constants.RANGE_OF_WORD_OF_6CHARACTERS);
                    break;
                case 7:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_6CHARACTERS, Constants.RANGE_OF_WORD_OF_7CHARACTERS);
                    break;
                case 8:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_7CHARACTERS, Constants.RANGE_OF_WORD_OF_8CHARACTERS);
                    break;
                case 9:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_8CHARACTERS, Constants.RANGE_OF_WORD_OF_9CHARACTERS);
                    break;
                case 10:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_9CHARACTERS, Constants.RANGE_OF_WORD_OF_10CHARACTERS);
                    break;
                default:
                    randomIndex = r.Next(Constants.RANGE_OF_WORD_OF_10CHARACTERS, Constants.RANGE_OF_WORD_OF_10_PLUS_CHARACTERS);
                    break;
            }
            return allWords[randomIndex];
        }
    }
}

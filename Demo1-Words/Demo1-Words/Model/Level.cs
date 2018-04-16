using Demo1_Words.Core.Interface;
using Demo1_Words.Factory.Interface;
using Demo1_Words.Model.Interface;

namespace Demo1_Words.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Factory;
    using Unity.Resolution;

    class Level : ILevel
    {
        private string chosenLevel;
        private IWordOperator wordOperator;
        private ITrieFactory trieFactory;
        public static ITrie trieFromDictionary;

        public Level(string chosenLevel , IWordOperator wordOperator , ITrieFactory trieFactory)
        {
            this.chosenLevel = chosenLevel;
            this.wordOperator = wordOperator;
            this.trieFactory = trieFactory;
            trieFromDictionary = trieFactory.CreateTrieFromDictionary();
        }

        public void RunLevel()
        {
            CustomIO.ClearInterface();
            string characters = wordOperator.Shuffle(wordOperator.GivingRandomWordWithNLenght(Int32.Parse(chosenLevel)));
            CustomIO.PrintOnNewLine(MenuMessages.pickedCharacters);
            characters.ToList().ForEach(x => Console.Write(x + " "));
            CustomIO.PrintOnNewLine(String.Empty);
            List<string> soutions = wordOperator.FindingSoutions(characters);
            string attempt = CustomIO.ReadNewLine();
            while (true)
            {
                if (attempt == "!surrender")
                {
                    Console.WriteLine("Words left are:");
                    soutions.ForEach(x => Console.WriteLine("->" + x));
                    break;
                }
                if (attempt == "!clear")
                {
                    Console.Clear();
                    Console.Write(MenuMessages.pickedCharacters);
                    characters.ToList().ForEach(x => Console.Write(x + " "));
                    Console.WriteLine();
                }
                if (attempt != null && !wordOperator.AtemptValidation(characters.Trim(), attempt.Trim()))
                {
                    Console.WriteLine("Please enter a valid input.");
                    attempt = Console.ReadLine();
                    continue;
                }
                if (trieFromDictionary.Search(attempt))
                {
                    soutions.Remove(attempt);
                    Console.WriteLine(attempt + @" is valid word!");
                    Console.WriteLine(soutions.Count + " words left.");
                }
                else
                {
                    Console.WriteLine(attempt + " is not valid word!");
                }
                if (soutions.Count == 0)
                {
                    Console.WriteLine("You found all the words !!!");
                    break;
                }
                attempt = Console.ReadLine();
            }
        }
    }
}
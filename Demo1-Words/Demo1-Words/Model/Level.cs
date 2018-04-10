﻿namespace Demo1_Words.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    class Level
    {
        private int chosenLevel;
        private WordOperator wordOperator;
        public Level(int chosenLevel)
        {
            wordOperator = new WordOperator();
            this.chosenLevel = chosenLevel;
        }
        public void RunLevel()
        {
            Console.Clear();
            string characters = wordOperator.Shuffle(wordOperator.GivingRandomWordWithNLenght(chosenLevel));
            Console.Write(MenuMessages.pickedCharacters);
            characters.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            List<string> resolved = wordOperator.FindingSoutions(characters);
            string attempt = Console.ReadLine();          
            while (true)
            {
                
                if (attempt == "!surrender")
                {
                    Console.WriteLine("Words left are:");
                    resolved.ForEach(x => Console.WriteLine("->" + x));
                    break;
                }
                if (attempt == "!clear")
                {
                    Console.Clear();
                    Console.Write(MenuMessages.pickedCharacters);
                    characters.ToList().ForEach(x => Console.Write(x + " "));
                    Console.WriteLine();
                    attempt = Console.ReadLine();
                    continue;
                }
                if (attempt != null && !wordOperator.AtemptValidation(characters.Trim(),attempt.Trim()))
                {
                    Console.WriteLine("Please enter a valid input.");
                    attempt = Console.ReadLine();
                    continue;
                }
                if (Engine.trieFromDictionary.Search(attempt))
                {
                    resolved.Remove(attempt);
                    Console.WriteLine(attempt + @" is valid word!");
                    Console.WriteLine(resolved.Count + " words left.");
                }             
                else
                {
                    Console.WriteLine(attempt + " is not valid word!");
                }
                if (resolved.Count == 0)
                {
                    Console.WriteLine("You found all the words !!!");
                    break;
                }
                attempt = Console.ReadLine();
            }
        }
    }
}
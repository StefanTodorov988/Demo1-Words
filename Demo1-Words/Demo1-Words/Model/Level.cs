namespace Demo1_Words.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    using Core.Interface;
    using Factory.Interface;
    using IO.Interface;
    using Interface;
    using Constants;
    class Level : ILevel
    {
        private string chosenLevel;
        private IWordOperator wordOperator;
        private ITrie trieFromDictionary;
        private IWriter writer;
        private IReader reader;
        private IPlayer player;
        public Level(string chosenLevel, IPlayer player, IWordOperator wordOperator, ITrieFactory trieFactory, IWriter writer, IReader reader)
        {
            this.player = player;
            this.writer = writer;
            this.reader = reader;
            this.chosenLevel = chosenLevel;
            this.wordOperator = wordOperator;
            trieFromDictionary = trieFactory.CreateTrieFromDictionary();
        }
        public void RunLevel()
        {
            string characters = wordOperator.Shuffle(wordOperator.GivingRandomWordWithNLenght(Int32.Parse(chosenLevel)));
            List<string> soutions = wordOperator.FindingSoutions(characters);
            PrintLevelStartingPoint(characters);
            string attempt = reader.ReadNewLine();
            while (true)
            {
                if (attempt == CommandConstants.SURRENDER_COMMAND)
                {
                    writer.PrintOnNewLine(MenuMessages.wordsLeft);
                    soutions.ForEach(x => writer.PrintOnNewLine("->" + x));
                    break;
                }
                if (attempt == CommandConstants.CLEAR_COMMAND)
                {
                    PrintLevelStartingPoint(characters);
                    attempt = reader.ReadNewLine();
                    continue;
                }
                if (attempt != null && !wordOperator.AtemptValidation(characters.Trim(), attempt.Trim()))
                {
                    writer.PrintOnNewLine(MenuMessages.invalidInput);
                    attempt = reader.ReadNewLine();
                    continue;
                }
                if (trieFromDictionary.Search(attempt))
                {
                    soutions.Remove(attempt);
                    writer.PrintOnNewLine(attempt + @" is valid word!");
                    player.Score += attempt.Length;
                    writer.PrintOnNewLine(soutions.Count + " words left.");
                }
                else
                {
                    writer.PrintOnNewLine(attempt + " is not valid word!");
                }
                if (soutions.Count == 0)
                {
                    writer.PrintOnNewLine(MenuMessages.wordsSolved);
                    break;
                }
                attempt = reader.ReadNewLine();
            }
        }
        public void PrintLevelStartingPoint(string characters)
        {
            writer.ClearInterface();
            writer.PrintOnNewLine(MenuMessages.pickedCharacters);
            characters.ToList().ForEach(x => writer.PrintOnLine(x + " "));
            writer.PrintOnNewLine(String.Empty);
        }
    }
}
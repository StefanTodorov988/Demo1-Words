namespace Demo1_Words.Core
{
    using System;
    using System.Collections.Generic;
    using Factory;
    using Model;
    public class Engine
    {
        private TrieFactory trieFactory;
        public static Trie trieFromDictionary;
        private LevelFactory levelFactory;
        private WordOperator wordOperator;

        public Engine()
        {
            wordOperator = new WordOperator();
        }
        public void Start()
        {
            Console.WindowWidth = Constants.ConsoleWidht;
            Console.WindowHeight = Constants.ConsoleHeigh;
            trieFactory = new TrieFactory();
            trieFromDictionary = trieFactory.CreateTrieFromDictionary();
            levelFactory = new LevelFactory();
            Console.WriteLine(MenuMessages.mainMenu);
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Level level;
                Console.WriteLine(MenuMessages.levelsMenu);
                int chosenLevel = int.Parse(Console.ReadLine());
                level = levelFactory.createLever(chosenLevel);
                level.RunLevel();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine(MenuMessages.resolverMenu);
                string characters = Console.ReadLine().Replace(" ", String.Empty).ToLower();
                bool passed = true;
                while (passed)
                {
                    if (wordOperator.SolverValidation(characters))
                    {
                        passed = false;
                        List<string> solutions = wordOperator.FindingSoution(characters);
                        if (!(solutions.Count == 0))
                        {

                            Console.WriteLine("Words you can build with these characters are:");
                            foreach (string solution in solutions)
                            {
                                Console.WriteLine(solution);
                            }
                        }
                    }
                    else
                    {
                        characters = Console.ReadLine().Replace(" ", String.Empty);
                    }
                }
            }
            else if (input == "3")
            {
                Console.Clear();
                Environment.Exit(0);
            }
        }
    }
}

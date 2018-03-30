namespace Demo1_Words.Core
{
    using System;
    using System.Collections.Generic;
    using Factory;
    using Model;
    class Engine
    {
        private TrieFactory trieFactory;
        public static Trie trieFromDictionary;
        private LevelFactory levelFactory;

        public void start()
        {
            Console.WindowWidth = Constants.CONSOLE_WIDHT;
            Console.WindowHeight = Constants.CONSOLE_HEIGH;
            trieFactory = new TrieFactory();
            trieFromDictionary = trieFactory.createTrieFromDictionary();
            levelFactory = new LevelFactory();
            Console.WriteLine(Menu.mainMenu);
            string input = Console.ReadLine();
            if (input == "1")
            {
                Console.Clear();
                Level level;
                Console.WriteLine(Menu.levelsMenu);
                int chosenLevel = int.Parse(Console.ReadLine());
                level = levelFactory.createLever(chosenLevel);
                level.runLevel();
            }
            else if (input == "2")
            {
                Console.Clear();
                Console.WriteLine(Menu.resolverMenu);
                string characters = Console.ReadLine().Replace(" ", String.Empty).ToLower();
                bool passed = true;
                while (passed)
                {
                    if (wordOperator.solverValidation(characters))
                    {
                        passed = false;
                        List<string> solutions = wordOperator.findingSoution(characters);
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

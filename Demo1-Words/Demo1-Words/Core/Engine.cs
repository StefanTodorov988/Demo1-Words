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
                Console.WriteLine(Menu.levelsMenu);
                Level level;
                int chosenLevel = int.Parse(Console.ReadLine());

                level = levelFactory.createLever(chosenLevel);
                level.runLevel();
            }
            else if (input == "2")
            { 
                Console.Clear();
                Console.WriteLine(Menu.resolverMenu);
                string characters = Console.ReadLine().Replace(" " , String.Empty);
                List<string> solutions = wordOperator.findingSoution(characters);
                Console.WriteLine("Words you can make with these characters are:");
                foreach (string solution in solutions)
                {
                    Console.WriteLine(solution);
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

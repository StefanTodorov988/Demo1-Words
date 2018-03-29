
namespace Demo1_Words.Model
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core;
    class Level
    {
        private int chosenLevel;
        public Level(int chosenLevel)
        {
            this.chosenLevel = chosenLevel;
        }
        public void runLevel()
        {
            Console.Clear();
            string characters = wordOperator.shuffle(wordOperator.givingRandomWordWithNLenght(chosenLevel));
            Console.Write("Characters you got are: ");
            characters.ToList().ForEach(x => Console.Write(x + " "));
            Console.WriteLine();
            List<string> resolved = wordOperator.findingSoution(characters);
            string attempt = Console.ReadLine();          
            while (true)
            {                
                if (attempt == "!surrender")
                {
                    Console.WriteLine("Words left are:");
                    resolved.ForEach(x => Console.WriteLine(x));
                    break;
                }
                if (resolved.Count == 0)
                {
                    Console.WriteLine("You found all the words !!!");
                    break;
                }
                if (Engine.trieFromDictionary.search(attempt))
                {
                    resolved.Remove(attempt);
                    Console.WriteLine(attempt + " is valid word!");
                }
                else
                {
                    Console.WriteLine(attempt + " is not valid word!");
                }
                attempt = Console.ReadLine();
            }
            Console.Write("Press any key to exit...");
            Console.ReadLine();
        }
    }
}

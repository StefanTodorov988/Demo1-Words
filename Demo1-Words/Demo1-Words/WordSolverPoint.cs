using System;
using System.Collections.Generic;
using Demo1_Words.Core;
using Demo1_Words.Model;

namespace Demo1_Words
{
    class WordSolverPoint : IGamePoint
    {
        private WordOperator wordOperator;

        public WordSolverPoint()
        {
            wordOperator = new WordOperator();
        }
        public void Run()
        {
            CustomIO.ClearInterface();
            Console.WriteLine(MenuMessages.resolverMenu);
            string characters = CustomIO.ReadNewLine().Replace(" ", String.Empty).ToLower();
            bool passed = true;
            while (passed)
            {
                if (wordOperator.SolverValidation(characters))
                {
                    passed = false;
                    List<string> solutions = wordOperator.FindingSoutions(characters);
                    if (!(solutions.Count == 0))
                    {
                        CustomIO.PrintOnNewLine("Words you can build with these characters are:");
                        foreach (string solution in solutions)
                        {
                            CustomIO.PrintOnNewLine(solution);
                        }
                    }
                }
                else
                {
                    characters = CustomIO.ReadNewLine().Replace(" ", String.Empty);
                }
            }
        }
    }
}

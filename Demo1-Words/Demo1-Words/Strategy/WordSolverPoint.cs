using Demo1_Words.Constants;
using Demo1_Words.Core.Interface;

namespace Demo1_Words
{
    using System;
    using System.Collections.Generic;
    using Core;
    using Model;

    class WordSolverPoint : IGamePoint
    {
        private IWordOperator wordOperator;

        public WordSolverPoint(IWordOperator wordOperator)
        {
            this.wordOperator = wordOperator;
        }
        public void Run()
        {
            CustomIO.ClearInterface();
            CustomIO.PrintOnNewLine(MenuMessages.resolverMenu);
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
        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.WORD_SOLVER;
        }
    }
}

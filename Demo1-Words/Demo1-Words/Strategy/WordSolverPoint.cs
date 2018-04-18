namespace Demo1_Words
{
    using Constants;
    using Core.Interface;
    using IO.Interface;
    using System;
    using System.Collections.Generic;
    using Core;
    class WordSolverPoint : IGamePoint
    {
        private IWordOperator wordOperator;
        private readonly IWriter writer;
        private readonly IReader reader;
        public WordSolverPoint(IWordOperator wordOperator ,  IWriter writer,IReader reader)
        {
            this.wordOperator = wordOperator;
            this.writer = writer;
            this.reader = reader;
        }
        public void Run()
        {
           writer.ClearInterface();
            writer.PrintOnNewLine(MenuMessages.resolverMenu);
            string characters = reader.ReadNewLine().Replace(" ", String.Empty).ToLower();
            bool passed = true;
            while (passed)
            {
                if (wordOperator.SolverValidation(characters))
                {
                    passed = false;
                    List<string> solutions = wordOperator.FindingSoutions(characters);
                    if (!(solutions.Count == 0))
                    {
                        writer.PrintOnNewLine(MenuMessages.solverMessage);
                        foreach (string solution in solutions)
                        {
                           writer.PrintOnNewLine(solution);
                        }
                    }
                }
                else
                {
                    characters = reader.ReadNewLine().Replace(" ", String.Empty);
                }
            }
        }
        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.WORD_SOLVER;
        }
    }
}

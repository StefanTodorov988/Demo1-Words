namespace Demo1_Words.Core.Interface
{
    using System.Collections.Generic;
    interface IWordOperator
    {
        bool AtemptValidation(string alphabet, string atempt);
        bool SolverValidation(string characters);
        string Shuffle(string str);
        List<string> FindingSoutions(string characters);
        string GivingRandomWordWithNLenght(int n);
    }
}

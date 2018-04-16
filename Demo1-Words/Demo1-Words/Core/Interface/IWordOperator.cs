using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1_Words.Core.Interface
{
    interface IWordOperator
    {
        bool AtemptValidation(string alphabet, string atempt);
        bool SolverValidation(string characters);
        string Shuffle(string str);
        List<string> FindingSoutions(string characters);
        string GivingRandomWordWithNLenght(int n);
    }
}

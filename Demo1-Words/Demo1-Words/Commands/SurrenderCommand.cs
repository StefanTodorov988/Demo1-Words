using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_Words.Commands.Interface;
using Demo1_Words.Constants;

namespace Demo1_Words.Commands
{
    class SurrenderCommand : ICommand
    {
        private List<string> solutions;
        public SurrenderCommand(List<string> solutions)
        {
            this.solutions = solutions;
        }
        public string Execute()
        {
            Console.WriteLine("Words left are:");
            solutions.ForEach(x => Console.WriteLine("->" + x));
            return CommandConstants.BREAK_COMMAND;
        }
    }
}

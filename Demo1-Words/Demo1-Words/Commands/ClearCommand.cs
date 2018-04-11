using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Demo1_Words.Commands.Interface;
using Demo1_Words.Constants;
using Demo1_Words.Core;
using Demo1_Words.Model;

namespace Demo1_Words.Commands
{
    class ClearCommand : ICommand
    {
        private string characters;
        private string attempt;
        public ClearCommand(string characters , ref string attempt)
        {
            this.characters = characters;
            this.attempt = attempt;
        }
        public string Execute()
        {
            CustomIO.ClearInterface();
            CustomIO.PrintOnLine(MenuMessages.pickedCharacters);
            characters.ToList().ForEach(x => CustomIO.PrintOnLine(x + " "));
            CustomIO.PrintOnNewLine(String.Empty);
            attempt = CustomIO.ReadNewLine();

            return CommandConstants.CONTINUE_COMMAND;
        }
    }
}

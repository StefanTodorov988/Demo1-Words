using System;
using System.Linq;
using Demo1_Words.Commands.Interface;
using Demo1_Words.Constants;
using Demo1_Words.Core;
using Demo1_Words.IO.Interface;
using Demo1_Words.Model;

namespace Demo1_Words.Commands
{
    class ClearCommand : ICommand
    {
        private string characters;
        private string attempt;
        private IWriter writer;
        private IReader reader;
        public ClearCommand(string characters ,  string attempt,    IWriter writer,  IReader reader)
        {
            this.writer = writer;
            this.reader = reader;
            this.characters = characters;
            this.attempt = attempt;
        }
        public string Execute()
        {
            writer.ClearInterface();
            writer.PrintOnNewLine(MenuMessages.pickedCharacters);
            characters.ToList().ForEach(x => writer.PrintOnLine(x + " "));
            writer.PrintOnNewLine(String.Empty);
            attempt = CustomIO.ReadNewLine();

            return CommandConstants.CONTINUE_COMMAND;
        }
    }
}

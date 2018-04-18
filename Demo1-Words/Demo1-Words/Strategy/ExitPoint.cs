namespace Demo1_Words
{
    using System;
    using Constants;
    using IO.Interface;
    class ExitPoint : IGamePoint
    {
        private readonly IWriter writer;
        public ExitPoint(IWriter writer)
        {
            this.writer = writer;

        }
        public void Run()
        {
            writer.ClearInterface();
            Environment.Exit(0);
        }

        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.EXIT;
        }
    }
}

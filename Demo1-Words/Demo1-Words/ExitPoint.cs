using System;
using Demo1_Words.Model;

namespace Demo1_Words
{
    class ExitPoint : IGamePoint
    {
        public void Run()
        {
            CustomIO.ClearInterface();
            Environment.Exit(0);
        }
    }
}

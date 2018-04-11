using System;
using Demo1_Words.Commands;

namespace Demo1_Words
{
    using Core;
    class StartUp
    {
        static void Main()
        {
            Engine engine = new Engine();
            engine.Start();
           
        }
    }
}
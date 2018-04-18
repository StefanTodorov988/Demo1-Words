namespace Demo1_Words.IO
{
    using System;
    using Interface;
    public class Reader : IReader
    {
        public  string ReadNewLine()
        {
            return Console.ReadLine();
        }
    }
}

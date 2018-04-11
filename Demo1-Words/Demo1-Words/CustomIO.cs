
namespace Demo1_Words.Model
{
    using System;
    using Constants;
    public class CustomIO
    {
        public static string ReadNewLine()
        {
            return Console.ReadLine();
        }

        public static void ClearInterface()
        {
            Console.Clear();
        }
        public static void PrintOnNewLine(string value)
        {
            Console.WriteLine(value);
        }
        public static void PrintOnLine(string value)
        {
            Console.Write(value);
        }

        public static void ConfigureSettings()
        {
            Console.WindowWidth = UserIntefraceConstants.ConsoleWidht;
            Console.WindowHeight = UserIntefraceConstants.ConsoleHeigh;
        }
    }
}

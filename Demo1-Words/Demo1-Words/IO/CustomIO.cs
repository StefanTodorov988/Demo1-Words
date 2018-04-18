namespace Demo1_Words.Model
{
    using System;
    using Constants;
    public class CustomIO
    {
        public static void ConfigureSettings()
        {
            Console.WindowWidth = UserIntefraceConstants.ConsoleWidht;
            Console.WindowHeight = UserIntefraceConstants.ConsoleHeigh;
        }
    }
}

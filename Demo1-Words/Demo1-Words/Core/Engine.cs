namespace Demo1_Words.Core
{
    using Factory.Interface;
    using Interface;
    using IO.Interface;
    using Model;
     class Engine : IEngine
    {
        private IGamePoint gamePoint;
        private IWriter writer;
        private IReader reader;
        private IGamePointFactory gamePointFactory;
        public Engine(IWriter writer , IReader reader , IGamePointFactory gamePointFactory)
        {
            this.writer = writer;
            this.reader = reader;
            CustomIO.ConfigureSettings();
            this.gamePointFactory = gamePointFactory;
        }
        public void Start()
        {
            writer.PrintOnNewLine(MenuMessages.mainMenu);
            string input = reader.ReadNewLine();
            gamePoint = gamePointFactory.CreateGamePoint(input);
            gamePoint.Run();
        }
    }
}

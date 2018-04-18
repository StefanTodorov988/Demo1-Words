namespace Demo1_Words
{
    using Constants;
    using Core;
    using Factory.Interface;
    using IO.Interface;
    using Model;
    using Model.Interface;
    using Unity;
     class NewGamePoint : IGamePoint
    {
        private ILevelFactory levelFactory;
        private IUnityContainer unityContainer;
        private ILevel level;
        private IWriter writer;
        private IReader reader;
        private IPlayer player;
        public NewGamePoint(IUnityContainer unityContainer,  IWriter writer , IReader reader ,IPlayer player, ILevelFactory levelFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.unityContainer = unityContainer;
            this.levelFactory = levelFactory;
            this.player = player;
        }
        public void Run()
        {
            player.InitializePlayer();
            writer.ClearInterface();
            writer.PrintOnNewLine(MenuMessages.levelsMenu);
            string chosenLevel = reader.ReadNewLine();
            level = levelFactory.CreateLevel(chosenLevel , unityContainer, player);
            level.RunLevel();
            player.SaveScore();
        }

        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.NEW_GAME;
        }
    }
}

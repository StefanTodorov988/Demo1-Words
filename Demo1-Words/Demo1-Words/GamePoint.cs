namespace Demo1_Words
{
    class GamePoint : IGamePoint
    {
        private IGamePoint gamePointStrategy;
        public GamePoint(IGamePoint gamePointStrategy)
        {
            this.gamePointStrategy = gamePointStrategy;
        }

        public void Run()
        {
            gamePointStrategy.Run();
        }
    }
}

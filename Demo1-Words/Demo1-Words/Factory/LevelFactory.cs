namespace Demo1_Words.Model
{
    using Core;
    using Factory;
    using Factory.Interface;
    using IO;
    using Unity;
    class LevelFactory : ILevelFactory
    {
        public Level CreateLevel(string chosenLevel, IUnityContainer unityContainer , IPlayer player)
        {
            return new Level( chosenLevel, player, unityContainer.Resolve<WordOperator>(), unityContainer.Resolve<TrieFactory>(), unityContainer.Resolve<Writer>(), unityContainer.Resolve<Reader>());
        }
    }
}

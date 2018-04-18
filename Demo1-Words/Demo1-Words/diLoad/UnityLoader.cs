namespace Demo1_Words.diLoad
{
    using Core;
    using Core.Interface;
    using Factory;
    using Factory.Interface;
    using IO;
    using IO.Interface;
    using Model;
    using Model.Interface;
    using Unity;
    using Constants;
    using Strategy;
    public class UnityLoader
    {
        public static IUnityContainer LoadContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();

            unityContainer.RegisterType<IEngine, Engine>();

            unityContainer.RegisterType<IWordOperator, WordOperator>();
            unityContainer.RegisterType<IGamePointFactory, GamePointFactory>();

            unityContainer.RegisterType<ILevelFactory, LevelFactory>();
            unityContainer.RegisterType<ITrieFactory, TrieFactory>();

            unityContainer.RegisterSingleton<ITrie, Trie>();
            unityContainer.RegisterType<ILevel, Level>();

            unityContainer.RegisterType<IReader, Reader>();
            unityContainer.RegisterType<IWriter, Writer>();

            unityContainer.RegisterSingleton<WordsContainer>();

            unityContainer.RegisterType<IGamePoint, NewGamePoint>("New game");
            unityContainer.RegisterType<IGamePoint, WordSolverPoint>("Word solver");
            unityContainer.RegisterType<IGamePoint, RankListPoint>("Rank list");
            unityContainer.RegisterType<IGamePoint, ExitPoint>("Exit");

            unityContainer.RegisterType<IPlayer, Player>();

            unityContainer.RegisterInstance(unityContainer);

            return unityContainer;
        }
    }
}

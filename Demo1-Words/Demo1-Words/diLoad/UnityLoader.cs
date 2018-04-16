using System;
using Demo1_Words.Core.Interface;
using Demo1_Words.Factory;
using Demo1_Words.Factory.Interface;
using Demo1_Words.Model;
using Demo1_Words.Model.Interface;
using Unity.Injection;

namespace Demo1_Words
{
    using Core;
    using Unity;

    public class UnityLoader
    {
        public static IUnityContainer LoadContainer()
        {
            IUnityContainer unityContainer = new UnityContainer();
            unityContainer.RegisterType<IEngine ,Engine>();
            unityContainer.RegisterType<IWordOperator, WordOperator>();
            unityContainer.RegisterType<IGamePointFactory, GamePointFactory>();
            unityContainer.RegisterType<ILevelFactory, LevelFactory>();
            unityContainer.RegisterType<ITrieFactory, TrieFactory>();
            unityContainer.RegisterType<ILevel, Level>(new InjectionConstructor("5"));

            unityContainer.RegisterType<ITrie, Trie>();
            unityContainer.RegisterType<IGamePoint, NewGamePoint>("New game");
            unityContainer.RegisterType<IGamePoint, WordSolverPoint>("Word solver");
            unityContainer.RegisterType<IGamePoint, ExitPoint>("Exit");



            return unityContainer;
        }
    }
}

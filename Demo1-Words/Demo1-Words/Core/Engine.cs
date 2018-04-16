using System.Collections.Generic;
using Demo1_Words.Core.Interface;
using Microsoft.Practices.Unity;
using Unity;

namespace Demo1_Words.Core
{
    using System;
    using Factory;
    using Model;
    public class Engine : IEngine
    {
        private IGamePoint gamePoint;
        private IUnityContainer unityContainer;
        private IGamePointFactory gamePointFactory;
        public Engine(IUnityContainer unityContainer)
        {
            CustomIO.ConfigureSettings();
            this.unityContainer = unityContainer;
            gamePointFactory = unityContainer.Resolve<GamePointFactory>();
        }
        public void Start()
        {
            Console.WriteLine(MenuMessages.mainMenu);
            string input = Console.ReadLine();
            gamePoint = gamePointFactory.CreateGamePoint(input);
            gamePoint.Run();
        }
    }
}

using System;
using Demo1_Words.Commands;
using Unity;

namespace Demo1_Words
{
    using Core;
    class StartUp
    {
        static void Main()
        {
            IUnityContainer unityContainer = UnityLoader.LoadContainer();
            Engine engine = unityContainer.Resolve<Engine>();
            engine.Start();
        }
    }
}
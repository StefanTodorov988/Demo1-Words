namespace Demo1_Words
{
    using Core;
    using diLoad;
    using Unity;
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
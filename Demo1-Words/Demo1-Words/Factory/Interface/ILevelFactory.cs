namespace Demo1_Words.Factory.Interface
{
    using Model;
    using Unity;
    interface ILevelFactory
    {
        Level CreateLevel(string chosenLevel, IUnityContainer unityContainer, IPlayer player);
    }
}

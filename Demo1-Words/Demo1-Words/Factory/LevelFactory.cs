using Demo1_Words.Factory.Interface;
using Demo1_Words.Model.Interface;
using Unity;

namespace Demo1_Words.Model
{
    class LevelFactory : ILevelFactory
    {
        public Level CreateLevel(string chosenLevel, IUnityContainer unityContainer)
        {
            return unityContainer.Resolve<Level>(chosenLevel);
        }
    }
}

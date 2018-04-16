using Unity;

namespace Demo1_Words.Factory
{
    using System.Collections.Generic;
    using System.Linq;
    class GamePointFactory : IGamePointFactory
    {
        private IGamePoint[] strategies;
        private IUnityContainer unityContainer;

        public GamePointFactory(IGamePoint[] strategies , IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            this.strategies = strategies;
        }

        public IGamePoint CreateGamePoint(string input)
        {
          return strategies.FirstOrDefault(strategie => strategie.IsApplicable(input)) ?? new ExitPoint();
        }
    }
}

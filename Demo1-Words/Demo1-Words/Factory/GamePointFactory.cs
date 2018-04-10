using Demo1_Words.Constants;

namespace Demo1_Words.Factory
{
    class GamePointFactory : IGamePointFactory
    {
        public IGamePoint CreateGamePoint(string input)
        {
            if (input == UserInputConstants.NEW_GAME)
            {
                return new NewGamePoint();
            }
            else if (input == UserInputConstants.WORD_SOLVER)
            {
                return new WordSolverPoint();
            }
            else // if (input == UserInputConstants.EXIT)
            {
                return new ExitPoint();
            }
        }
    }
}

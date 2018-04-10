using Demo1_Words.Core;
using Demo1_Words.Model;

namespace Demo1_Words
{
    public class NewGamePoint : IGamePoint
    {
        private LevelFactory levelFactory;
        public NewGamePoint()
        {
                levelFactory = new LevelFactory();
        }
        public void Run()
        {
            CustomIO.ClearInterface();
            Level level;
            CustomIO.PrintOnNewLine(MenuMessages.levelsMenu);
            int chosenLevel = int.Parse(CustomIO.ReadNewLine());
            level = levelFactory.createLever(chosenLevel);
            level.RunLevel();
        }
    }
}

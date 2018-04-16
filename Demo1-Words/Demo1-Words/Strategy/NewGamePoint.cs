using System;
using Demo1_Words.Constants;
using Demo1_Words.Core;
using Demo1_Words.Factory.Interface;
using Demo1_Words.Model;
using Demo1_Words.Model.Interface;
using Unity;

namespace Demo1_Words
{
    public class NewGamePoint : IGamePoint
    {
        private ILevelFactory levelFactory;
        private IUnityContainer unityContainer;
        private ILevel level;

        public NewGamePoint(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
            levelFactory = unityContainer.Resolve<LevelFactory>();
        }
        public void Run()
        {
            CustomIO.ClearInterface();
            CustomIO.PrintOnNewLine(MenuMessages.levelsMenu);
            string chosenLevel = CustomIO.ReadNewLine();
            level = levelFactory.CreateLevel(chosenLevel , unityContainer);
            level.RunLevel();
        }

        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.NEW_GAME;
        }
    }
}

namespace Demo1_Words
{
    using System;
    using System.IO;
    using Constants;
    using Core;
    using IO.Interface;
    public class Player : IPlayer
    {
        private IReader reader;
        private IWriter writer;
        private WordsContainer wordsContainer;
        public Player(IReader reader, IWriter writer , WordsContainer wordsContainer)
        {
            this.reader = reader;
            this.writer = writer;
            this.wordsContainer = wordsContainer;
        }
        public string Name { get; set; }
        public int Score { get; set; }
        public void InitializePlayer()
        {
            writer.ClearInterface();
            writer.PrintOnLine(MenuMessages.nameSetting);
            string name = reader.ReadNewLine().Trim();
            while (true)
            {
                if (wordsContainer.PlayersRanking.ContainsKey(name))
                {
                    writer.ClearInterface();
                    writer.PrintOnLine(MenuMessages.nameAlreadyTaken);
                    name = reader.ReadNewLine();
                }
                else
                {
                    Name = name.Trim();
                    break;
                }
            }
            writer.ClearInterface();
        }
        public void SaveScore()
        {
            File.AppendAllText("Scores.txt", Environment.NewLine + Name + " " + Score );
            writer.PrintOnNewLine(MenuMessages.finalScore + Score +" points.");
        }
    }
}

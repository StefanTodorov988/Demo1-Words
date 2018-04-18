namespace Demo1_Words.Strategy
{
    using System.Linq;
    using Constants;
    using IO.Interface;
    using Unity.Interception.Utilities;
    class RankListPoint : IGamePoint
    {
        private IWriter writer;
        private WordsContainer wordsContainer;
        public RankListPoint(IWriter writer, WordsContainer wordsContainer)
        {
            this.writer = writer;
            this.wordsContainer = wordsContainer;
        }
        public void Run()
        {
            writer.ClearInterface();
            int i = 0;
            wordsContainer.PlayersRanking.OrderByDescending(x => x.Value).ForEach(x => writer.PrintOnNewLine(++i + " " + x.Key.PadRight(10,'.')  + x.Value));

        }
        public bool IsApplicable(string input)
        {
            return input == UserInputConstants.RANKLIST;
        }
    }
}

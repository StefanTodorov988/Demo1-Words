namespace Demo1_Words.Constants
{
    using Unity.Interception.Utilities;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Core;
    public class WordsContainer
    {
        public WordsContainer()
        {
            AllWords = File.ReadAllLines("legitWords.txt").ToList();
            RangeDictionary = new Dictionary<int, int>
            {
                {2,0},
                {3,WordIndexConstants.RANGE_OF_WORD_OF_3CHARACTERS},
                {4,WordIndexConstants.RANGE_OF_WORD_OF_4CHARACTERS},
                {5,WordIndexConstants.RANGE_OF_WORD_OF_5CHARACTERS},
                {6,WordIndexConstants.RANGE_OF_WORD_OF_6CHARACTERS},
                {7,WordIndexConstants.RANGE_OF_WORD_OF_7CHARACTERS},
                {8,WordIndexConstants.RANGE_OF_WORD_OF_8CHARACTERS},
                {9,WordIndexConstants.RANGE_OF_WORD_OF_9CHARACTERS},
                {10,WordIndexConstants.RANGE_OF_WORD_OF_10CHARACTERS},
                {11,WordIndexConstants.RANGE_OF_WORD_OF_10_PLUS_CHARACTERS}
            };
            PlayersRanking = new Dictionary<string, int>();
            File.ReadAllLines("Scores.txt").ForEach(x=> PlayersRanking.Add(x.Split(' ')[0] , int.Parse(x.Split(' ')[1])));
        }
        public List<string> AllWords { get; set; }
        public Dictionary<int, int> RangeDictionary { get; set; }
        public Dictionary<string, int> PlayersRanking { get; set; }
    }
}

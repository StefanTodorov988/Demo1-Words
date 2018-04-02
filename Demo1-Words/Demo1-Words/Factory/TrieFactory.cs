namespace Demo1_Words.Factory
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class TrieFactory
    {
        public Trie createTrieFromDictionary()
        {
            Trie trieOfAllWords = new Trie();
            List<string> allWords;
            allWords = File.ReadAllLines("legitWords.txt").ToList();
            allWords.ForEach(x => trieOfAllWords.Insert(x));
            return trieOfAllWords;
        }
    }
}

using Demo1_Words.Factory.Interface;

namespace Demo1_Words.Factory
{
    using System.Collections.Generic;
    using System.IO;
    using Model;
    using System.Linq;
    class TrieFactory : ITrieFactory
    {
        public Trie CreateTrieFromDictionary()
        {
            Trie trieOfAllWords = new Trie();
            List<string> allWords;
            allWords = File.ReadAllLines("legitWords.txt").ToList();
            allWords.ForEach(x => trieOfAllWords.Insert(x));
            return trieOfAllWords;
        }
    }
}

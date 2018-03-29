namespace Demo1_Words.Factory
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    class TrieFactory
    {
        public TrieFactory()
        {

        }
        public Trie createTrieFromDictionary()
        {
            Trie trieOfAllWords = new Trie();
            List<string> allWords;
            allWords = File.ReadAllLines(@"C:\Users\Stefan\Desktop\Demo1-Words\Demo1-Words\Demo1-Words\resource\words.txt").ToList();
            allWords.ForEach(x => trieOfAllWords.insert(x));
            return trieOfAllWords;
        }
    }
}

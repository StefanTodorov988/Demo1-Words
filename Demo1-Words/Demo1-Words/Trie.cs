using System.Collections.Generic;

namespace Demo1_Words
{
    using System;

    class Trie
    {
        public Dictionary<char, Trie> children;
        public bool endOfWord;
        public Trie()
        {
            children = new Dictionary<char, Trie>();
            endOfWord = false;
        }
        public void insert(string word)
        {
            Trie current = this;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                Trie node;
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                }
                else
                { 
                    node = new Trie();
                    current.children.Add(ch, node);
                }
                current = node;
            }
            current.endOfWord = true;
        }
        public bool search(String word)
        {
            Trie current = this;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                Trie node;
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                }
                else
                {
                    return false;
                }
                current = node;
            }
            return current.endOfWord;
        }
    }
}

using Demo1_Words.Model.Interface;

namespace Demo1_Words.Model
{
    using System.Collections.Generic;
    public class Trie : ITrie
    {
        public class TrieNode
        {
            public Dictionary<char, TrieNode> children;
            public bool endOfWord;
            public TrieNode()
            {
                children = new Dictionary<char, TrieNode>();
                endOfWord = false;
            }
        }
        private TrieNode root;
        public Trie()
        {
            root = new TrieNode();
        }
        public void Insert(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node = null;
                if (current.children.ContainsKey(ch))
                {
                    node = current.children[ch];
                }
                else
                {
                    node = new TrieNode();
                    current.children.Add(ch, node);
                }
                current = node;
            }
            current.endOfWord = true;
        }
        public bool Search(string word)
        {
            TrieNode current = root;
            for (int i = 0; i < word.Length; i++)
            {
                char ch = word[i];
                TrieNode node;
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
        public void Delete(string word)
        {
            Delete(root, word, 0);
        }
        private bool Delete(TrieNode current, string word, int index)
        {
            if (index == word.Length)
            {
                if (!current.endOfWord)
                {
                    return false;
                }
                current.endOfWord = false;
                return current.children.Count == 0;
            }
            char ch = word[index];
            TrieNode node = current.children[ch];
            if (node == null)
            {
                return false;
            }
            bool shouldDeleteCurrentNode = Delete(node, word, index + 1);
            if (shouldDeleteCurrentNode)
            {
                current.children.Remove(ch);
                return current.children.Count == 0;
            }
            return false;
        }
    }
}
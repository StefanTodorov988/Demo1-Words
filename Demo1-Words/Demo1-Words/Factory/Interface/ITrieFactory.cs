using System;
using Demo1_Words.Model;

namespace Demo1_Words.Factory.Interface
{
    interface ITrieFactory
    {
        Trie CreateTrieFromDictionary();
    }
}

namespace Demo1_Words.Factory.Interface
{
    using Model.Interface;
    interface ITrieFactory
    {
        ITrie CreateTrieFromDictionary();
    }
}

namespace Demo1_Words.Factory
{
    using Constants;
    using Interface;
    using Model.Interface;
    using Unity;
    using Model;
    class TrieFactory : ITrieFactory
    {
        private IUnityContainer unityContainer;
        private WordsContainer wordsContainer;
        public TrieFactory(IUnityContainer unityContainer , WordsContainer wordsContainer)
        {
            this.wordsContainer = wordsContainer;
            this.unityContainer = unityContainer;
        }

        public ITrie CreateTrieFromDictionary()
        {
            Trie trieOfAllWords = unityContainer.Resolve<Trie>();
            wordsContainer.AllWords.ForEach(x => trieOfAllWords.Insert(x));
            return trieOfAllWords;
        }
    }
}

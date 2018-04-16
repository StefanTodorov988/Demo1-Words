namespace Demo1_Words.Model.Interface
{
    interface ITrie
    {
        void Insert(string word);
        bool Search(string word);
        void Delete(string word);
    }
}

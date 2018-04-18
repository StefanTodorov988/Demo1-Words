namespace Demo1_Words
{
    public interface IPlayer
    {
         string Name { get; set; }
         int Score { get; set; }
        void InitializePlayer();
        void SaveScore();
    }
}

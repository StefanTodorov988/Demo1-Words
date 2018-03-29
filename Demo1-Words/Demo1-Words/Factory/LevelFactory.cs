namespace Demo1_Words.Model
{
    class LevelFactory
    {
        public Level createLever(int level)
        {
            Level lever = new Level(level);
            return lever;
        }
    }
}

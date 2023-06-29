namespace Assets.Scenes.VLGamingStudy0328
{
    public class CreatureSeed : ICloneableObject<CreatureSeed>
    {
        public CreatureSeed(Creature creature, SeedRandom seedRandom, int maxCount)
        {
            Creature = creature;
            SeedRandom = seedRandom;
            MaxCount = maxCount;
        }

        public string Name { set; get; }
        public Creature Creature { set; get; }
        public SeedRandom SeedRandom { set; get; }
        public int MaxCount { get; internal set; }

        public CreatureSeed Clone()
        {
            return new CreatureSeed(Creature, SeedRandom.Clone(), MaxCount);
        }
    }
}

namespace Classes
{
    public class Move
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int CurrentPP { get; private set; }
        public int MaxPP { get; private set; }
        public int Accuracy { get; private set; }
        public string Description { get; private set; }
        public bool HasOverworldEffect { get; private set; }
        public int BasePower { get; private set; }
        public int MinLevel { get; private set; }
        private Type type;

        public Move(int id, string name, int currentPp, int maxPp, int accuracy, string description, bool hasOverworldEffect, int basePower, int minLevel)
        {
            Id = id;
            Name = name;
            CurrentPP = currentPp;
            MaxPP = maxPp;
            Accuracy = accuracy;
            Description = description;
            HasOverworldEffect = hasOverworldEffect;
            BasePower = basePower;
            MinLevel = minLevel;
        }

        public Type GetType()
        {
            return type;
        }
    }
}

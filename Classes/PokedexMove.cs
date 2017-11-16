namespace Classes
{
    public class PokedexMove
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int MaxPP { get; private set; }
        public string Description { get; private set; }
        public decimal Accuracy { get; private set; }
        public bool HasOverWorldEffect { get; private set; }
        public int BasePower { get; private set; }

    }
}

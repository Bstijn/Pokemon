namespace Classes
{
    public class Type
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Type(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public decimal CalculateEffectRatio(Type type)
        {
            decimal ratio = 1;

            // TODO: implementeer dit

            return ratio;
        }
    }
}

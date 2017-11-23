using System;

namespace Classes
{
    public abstract class Consumable : Item
    {
        public int Cost { get; set; }

        public Consumable(int id, string name, int cost, string description) : base(id, name, description)
        {
            Cost = cost;
        }

        public void Use()
        {
            throw new NotImplementedException();
        }
    }
}

using System;

namespace Classes
{
    public class Revive : Consumable
    {
        public Revive(int id, string name, int cost, string description, int percentage) : base(id, name, cost, description)
        {
            this.Percentage = percentage;
        }

        public int Percentage { get; private set; }

        public override bool Use(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }
    }
}

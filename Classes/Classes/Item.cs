﻿namespace Classes.Classes
{
    public abstract class Item
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public int Cost { get; private set; }
        public string Description { get; private set; }

        protected Item(int id, string name, int cost, string description)
        {
            Id = id;
            Name = name;
            Cost = cost;
            Description = description;
        }
    }
}

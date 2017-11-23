using System;
using System.Collections.Generic;


namespace Classes
{
    public abstract class Character
    {
        public string Name { get; private set; }
        public int Id { get; private set; }
        public string Gender { get; private set; }
        public int Money { get; private set; }
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public Location CurrentLocation { get; private set; }
        public List<Possesion> Inventory { get; private set; }
        public List<Pokemon> Pokemons { get; private set; }
        
        public string Talk(Dialogue dialogue)
        {
            throw new NotImplementedException();
        }
    }
}

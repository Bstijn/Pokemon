using System.Collections.Generic;

namespace Classes.Classes
{
    public class Pokemart : Building
    {
        private List<Consumable> shopItems;

        public Pokemart(int id, int sizeX, int sizeY, string name, List<Passage> passages, List<Consumable> shopItems) : base(id, sizeX, sizeY, name, passages)
        {
            this.shopItems = shopItems;
        }
    }
}

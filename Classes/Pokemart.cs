using System.Collections.Generic;

namespace Classes
{
    public class Pokemart : Building
    {
        public List<Consumable> ShopItems { get; private set; }

        public Pokemart(int id, int sizeX, int sizeY, string name, List<Passage> passages,List<Consumable> shopItems) : base(id, sizeX, sizeY, name, passages)
        {
            this.ShopItems = shopItems;
        }


    }
}

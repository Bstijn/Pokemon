using System.Collections.Generic;

namespace Classes
{
    public class Pokemart : Building
    {
        public List<Consumable> ShopItems { get; private set; }

        public Pokemart(int id, string name, List<Passage> passages,List<Consumable> shopItems) : base(id, name, passages)
        {
            this.ShopItems = shopItems;
        }


    }
}

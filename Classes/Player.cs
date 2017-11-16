using System;

namespace Classes
{
    public class Player : Character, IItemUser, ISellBuy
    {
        public int Wins { get; private set; }
        public int Loses { get; private set; }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public void UseItem()
        {
            throw new NotImplementedException();
        }

        public void Walk(int x, int y)
        {
            throw new NotImplementedException();
        }

        public void EncounterPokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void EncounterOppenent(Oppenent oppenent)
        {
            throw new NotImplementedException();
        }

        public void ManageParty()
        {
            throw new NotImplementedException();
        }

        public void ManagePC()
        {
            throw new NotImplementedException();
        }

        public void CheckPlayerInfo()
        {
            throw new NotImplementedException();
        }

        public void CheckPokedex()
        {
            throw new NotImplementedException();
        }

        public void CheckInventory()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public void CatchPokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void RunAway()
        {
            throw new NotImplementedException();
        }

        public void BuyItem(Consumable consumable, int amount)//TODO Stijn: saving to database will still be added.
        {
            if (consumable.Cost * amount <= Money)
            {
                Money -= consumable.Cost * amount;
                for (int i = 0; i < amount; i++)
                {
                    Inventory.Add(consumable);
                }
            }
        }

        public void SellItem(Consumable consumable, int amount)//TODO Stijn: check if the removing of list
        {
            Money += consumable.Cost * amount;
            for (int i = 0; i < amount; i++)
            {
                if (consumable is Pokeball)
                {
                    Pokeball removingpokeball = new Pokeball();
                    foreach(Pokeball pokeball in Inventory)
                    {
                        removingpokeball = pokeball;
                        break;
                    }
                    Inventory.Remove(removingpokeball);

                }
                else if (consumable is Revive)
                {

                }
                else if (consumable is Potion)
                {

                }
            }
        }
    }
}

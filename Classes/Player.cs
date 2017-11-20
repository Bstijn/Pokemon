using System;
using Classes.Exceptions;

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

        public void BuyItem(Consumable consumable, int amount)
        {
            throw new NotImplementedException();
        }

        public void SellItem(Consumable consumable, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                Consumable consToRemove = null;
                foreach (Consumable consinInv in Inventory)
                {
                    if (consinInv.Name == consumable.Name)
                    {
                        consToRemove = consinInv;
                        break;
                    }
                }
                if (consToRemove != null)
                {
                    Money += consToRemove.Cost;
                    Inventory.Remove(consToRemove);
                }
                else
                {
                    throw new NotEnoughItemsToSellExceptions();
                }
            }
        }
        public void GiveItem(Item item)
        {
            if(item is NonConsumable)
            {
                foreach(NonConsumable NC in Inventory)
                {
                    if(NC.Name == item.Name)
                    {
                        return;
                    }
                }
            }
            Inventory.Add(item);
        }
        public void GiveMoney(int amount)
        {
            Money += amount;
        }
    }
}

using System;
using Classes.Exceptions;

namespace Classes
{
    public class Player : Character, IItemUser
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

        public void GiveMoney(int money)
        {
            Money += money;
        }

        public void BuyItem(Consumable consumable, int amount)//TODO Stijn: saving to database will still be added. or it will be added in the scenechange save or save game function.
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

        public void SellItem(Consumable consumable, int amount)//TODO Stijn: Or just remove it from the list and save it in the database when the scene changes or when games saves or change it immediatelly in the database
        {
            Money += consumable.Cost * amount;
            for (int i = 0; i < amount; i++)
            {
                Consumable removingconsumable = null;
                foreach (Consumable consumableinInv in Inventory)
                {
                    if (consumableinInv.Name == consumable.Name)
                    {
                        removingconsumable = consumable;
                        break;
                    }
                }
                if (removingconsumable != null)
                {
                    Inventory.Remove(removingconsumable);
                }
                else
                {
                    throw new NotEnoughConsumablesToSellException();
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
                        throw new Exception();
                    }
                }

            }
            Inventory.Add(item);

        }
    }
}


using System;
using System.Collections.Generic;
using Classes.Exceptions;

namespace Classes
{
    public class Player : Character, IItemUser, ISellBuy
    {

        public int Wins { get; private set; }
        public int Loses { get; private set; }
        public Player(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Item> inventory, List<Pokemon> pokemons, int wins, int losses)
            : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.Wins = wins;
            this.Loses = losses;
        }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public void UseItem(Item item)//keyItem such as bike might also need to be used.
        {
            throw new NotImplementedException();
        }

        public void Walk(int x, int y)//dont forget to change the posX and posY when player moves so u can save the position.
        {
            throw new NotImplementedException();
        }

        public void EncounterPokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public void EncounterOppenent(Opponent oppenent)
        {
            throw new NotImplementedException();
        }

        public void ManageParty()//open party menu
        {
            throw new NotImplementedException();
        }

        public void ManagePC()//open PC menu check might be required in unity.
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
            if (Money >= consumable.Cost * amount)
            {
                for (int i = 0; i < amount; i++)
                {
                    Inventory.Add(consumable);

                }
                Money -= consumable.Cost * amount;
            }
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
            if (item is NonConsumable)
            {
                foreach (NonConsumable NC in Inventory)
                {
                    if (NC.Name == item.Name)
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

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

        /// <summary>
        /// used for keyItems in player inventory
        /// </summary>
        /// <param name="item">stands for a keyitem</param>
        public void UseItem(Item item)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// uses consumable on a pokemon and will remove it from the inventory
        /// </summary>
        /// <param name="pokemon">target for consumable</param>
        /// <param name="consumable">which consumable you want to use</param>
        public void UseItem(Pokemon pokemon, Consumable consumable)
        {
            foreach (Consumable consInInv in Inventory)
            {
                if (consInInv.Id == consumable.Id)
                {
                    consumable = consInInv;
                    break;
                }
            }
            if (!Inventory.Contains(consumable))
            {
                throw new ItemNotInInventoryException(); 
            }
            if (consumable is Potion)
            {
                pokemon.Heal((consumable as Potion).HealAmount);
            }
            else if(consumable is Revive)
            {
                pokemon.Revive((consumable as Revive).Percentage);
            }
            else if (consumable is Pokeball)
            {
                throw new NotImplementedException();
            }
            Inventory.Remove(consumable);
        }

        public void Walk(int x, int y)//dont forget to change the posX and posY when player moves so u can save the position.
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

        public void ManageParty(Pokemon pokemon1, Pokemon pokemon2)//switches 2 pokemon of position in the Party.
        {
            int index1 = Pokemons.IndexOf(pokemon1);
            int index2 = Pokemons.IndexOf(pokemon2);
            if(index1 < index2)
            {
                Pokemons.RemoveAt(index2);
                Pokemons.Insert(index1, pokemon2);
                Pokemons.Remove(pokemon1);
                Pokemons.Insert(index2,pokemon1);
            }
            else
            {
                Pokemons.RemoveAt(index1);
                Pokemons.Insert(index2, pokemon1);
                Pokemons.Remove(pokemon2);
                Pokemons.Insert(index1, pokemon2);
            }
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

        public void UseItemInBattle(Pokemon targetForItem, Consumable consumable)
        {
            foreach(Consumable consInInv in Inventory)
            {
                if(consInInv.Id == consumable.Id)
                {
                    consumable = consInInv;
                    break;
                }
            }
            if (!Inventory.Contains(consumable))
            {
                throw new ItemNotInInventoryException();
            }

            if (consumable is Potion)
            {
                targetForItem.Heal((consumable as Potion).HealAmount);
            }
            else if (consumable is Revive)
            {
                targetForItem.Revive((consumable as Revive).Percentage);
            }
            else if (consumable is Pokeball)
            {
                throw new NotImplementedException();
            }
            Inventory.Remove(consumable);
        }
    }
}

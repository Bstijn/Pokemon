using System;
using System.Collections.Generic;
using System.Linq;
using Classes.Exceptions;

namespace Classes
{
    public class Player : Character, IItemUser, ISellBuy
    {
        public int Wins { get; private set; }
        public int Loses { get; private set; }
        public Pokecenter LastVisitedPokeCenter { get; private set; }
        public Player(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> pokemons, int wins, int losses,Pokecenter lastVistedPokeCenter)
            : base(name, id, gender, money, posX, posY, currentLocation, inventory, pokemons)
        {
            this.LastVisitedPokeCenter = lastVistedPokeCenter;
            this.Wins = wins;
            this.Loses = losses;
        }

        public Player(string name, int id, string gender, int money, int posX, int posY, int wins, int losses) 
            : base(name, id, gender, money, posX, posY)
        {
            this.Wins = wins;
            this.Loses = losses;
            Inventory = new List<Possesion>();
            SetPokemons(new List<Pokemon>());
            SetCurrentLocation(locationRepo.GetCurrentLocation(1));
        }


        public bool UseItemInBattle(Consumable consumable, Pokemon targetPokemon)
        {
            var useditem = Inventory.First(i => consumable.Id == i.Item.Id);
            useditem.ItemUsed();
            if (consumable.GetType() == typeof(Pokeball))
            {
                if (consumable.Use(targetPokemon))
                    return true;
                return false;
            }

            var selectedPokemon = Pokemons.First(p => targetPokemon.Id == p.Id);
            if (consumable.GetType() == typeof(Revive))
            {
                var revive = (Revive)consumable;
                selectedPokemon.Revive(revive.Percentage);
                return true;
            }

            if (consumable.GetType() == typeof(Potion))
            {
                var potion = (Potion)consumable;
                selectedPokemon.HealByPotion(potion);
                return true;
            }
            return false;
        }
        /// <summary>
        /// uses consumable on a pokemon and will remove it from the inventory
        /// </summary>
        /// <param name="pokemon">target for consumable</param>
        /// <param name="consumable">which consumable you want to use</param>
        public void UseItem(Pokemon pokemon, Consumable consumable)
        {
            var useditem = Inventory.First(i => consumable.Id == i.Item.Id);
            useditem.ItemUsed();
            if (consumable is Potion)
            {
                pokemon.Heal((consumable as Potion).HealAmount);
            }
            else if(consumable is Revive)
            {
                pokemon.Revive((consumable as Revive).Percentage);
            }
            useditem.ItemUsed();
        }

        private Possesion PossesionCheck(Consumable consumable)
        {
            Possesion possesion = new Possesion();
            foreach (Possesion consInInv in Inventory)
            {
                if (consInInv.Item.Id == consumable.Id)
                {
                    possesion = consInInv;
                    break;
                }
            }
            return possesion;
        }
        public void Walk(int x, int y)//dont forget to change the posX and posY when player moves so u can save the position.
        {
            throw new NotImplementedException();
        }

        public void EncounterPokemon(Pokemon pokemon)//verwerk in db
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

        public Player CheckPlayerInfo()
        {
            throw new NotImplementedException();
        }

        public Pokedex CheckPokedex()
        {
            throw new NotImplementedException();
        }

        public List<Item> CheckInventory()
        {
            throw new NotImplementedException();
        }

        public void Save()//verwerk met db classes
        {
            throw new NotImplementedException();
        }

        public void Load()//verwerk met db classes misschien de return Type aan passen
        {
            throw new NotImplementedException();
        }

        public void CatchPokemon(Pokemon pokemon)//boolean of  pokemon returnen of het gelukt is.
        {
            if (Pokemons.Count() < 6)
            {
                Pokemons.Add(pokemon);
            }
            else
            {
                
            }
        }

        public void RunAway()
        {
            throw new NotImplementedException();
        }

        public void BuyItem(Consumable consumable, int amount)
        {
            //TODO IMPLEMENTEER JOEL POSSESION
        }

        public void SellItem(Consumable consumable, int amount)
        {
            //TODO IMPLEMENTEREN JOEL POSSESION
        }
        public void GiveItem(Item item)
        {
            //TODO IMPLEMENTEREN JOEL POSSESION
        }
        public void GiveMoney(int amount)
        {
            Money += amount;
        }

        public void UseItemInBattle(Pokemon targetForItem, Consumable consumable)
        {
            //TODO IMPLEMENTEER JOEL POSSESION
        }

        public void SetLastVistedPokeCenter(Pokecenter pokeCenter)
        {
            //implement in database;
            throw new NotImplementedException();

        }
        public void GoToLocation(Passage passage)//Maybe check with database if character can go to location.
        {
            CurrentLocation = passage.ToLocation;
            PosX = passage.ToX;
            PosY = passage.ToY;
        }
    }
}

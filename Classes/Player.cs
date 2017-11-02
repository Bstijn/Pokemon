using System;
using System.Collections.Generic;

namespace Classes
{
    public class Player : Character, IItemUser, ISellBuy
    {
        public int Wins { get; private set; }
        public int Loses { get; private set; }

        public Player(string name, int id, string gender, int money, int posX, int posY, Location currentLocation, List<Possesion> inventory, List<Pokemon> partyPokemon, int wins, int loses) : base(name, id, gender, money, posX, posY, currentLocation, inventory, partyPokemon)
        {
            Wins = wins;
            Loses = loses;
        }

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

        public void BuyItem(Consumable consumable, int amount)
        {
            throw new NotImplementedException();
        }

        public void SellItem(Consumable consumable, int amount)
        {
            throw new NotImplementedException();
        }
    }
}

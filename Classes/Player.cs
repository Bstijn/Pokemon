using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }
    }
}

using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;

namespace Classes.Repos
{
    public class PlayerRepository
    {
        private ICharacterContext context;
        private CharacterRepository repo;

        public PlayerRepository()
        {
            context = new CharacterContext();
            repo = new CharacterRepository();
        }

        public void Save()
        {
            //context.Save();
        }

        public Player Load()
        {
            int playerID = context.GetCharacterIDForPlayer();
            string name = context.GetCharacter(playerID)[1].ToString();
            string gender = context.GetCharacter(playerID)[2].ToString();
            int money = Convert.ToInt32(context.GetCharacter(playerID)[3]);
            int wins = Convert.ToInt32(context.GetCharacter(playerID)[4]);
            int losses = Convert.ToInt32(context.GetCharacter(playerID)[5]);
            Location location = repo.GetCurrentLocation(playerID);
            List<Possesion> possessions = new List<Possesion>();
            foreach (Item item in repo.GetInventory(playerID))
            {
                possessions.Add(item);
            }
            return new Player(name, playerID, gender, money, posX, posY, location, possessions, pokemon, wins, losses, lastVistedPokeCenter);
        }
    }
}

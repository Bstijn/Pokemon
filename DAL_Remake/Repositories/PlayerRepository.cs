using DAL_Remake.SQLContexts;
using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DAL_Remake.Repositories
{
    public class PlayerRepository
    {
        private IPlayerContext context;

        public PlayerRepository(IPlayerContext context)
        {
            context = new PlayerContext();
        }

        public void Save()
        {
            context.Save();
        }

        public void Load()
        {
            context.Load();
        }
    }
}

using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Repos
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

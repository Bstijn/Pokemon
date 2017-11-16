using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Remake.Repositories
{
    public class PlayerRepository
    {
        private IPlayerContext context;

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

using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;

namespace Classes.Repos
{
    public class PlayerRepository
    {
        private IPlayerContext context;

        public PlayerRepository()
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

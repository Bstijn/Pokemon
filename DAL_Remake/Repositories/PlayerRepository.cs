using DAL_Remake.Interfaces;

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

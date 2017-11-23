using DAL_Remake.SQLContexts;
using DAL_Remake.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL_Remake.Repositories
{
    public class LocationRepository
    {
        private ILocationContext context;


        public LocationRepository(ILocationContext context)
        {
            context = new LocationContext();
        }

        public List<object[]> GetCharacters(int locationID)
        {
            return context.GetCharacters(locationID);


        public List<object[]> GetPassages()
        {
            return context.GetPassages();
        }

        public List<object[]> GetPokemon()
        {
            return context.GetPokemon();
        }
    }
}

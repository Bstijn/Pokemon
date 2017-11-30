using DAL_Remake.Interfaces;
using DAL_Remake.SQLContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Repos
{
    public class LocationRepository
    {
        private ILocationContext context;


        public LocationRepository(ILocationContext context)
        {
            context = new LocationContext();
        }

        public Gymleader GetGymleader(int locationID)
        {
            object[] data = context.GetGymleader(locationID);


            return null;
        }

        public Nurse GetNurse(int locationID)
        {
            object[] data = context.GetNurse(locationID);

            return null;
        }

        public ShopKeeper GetShopkeeper(int locationID)
        {
            object[] data = context.GetShopkeeper(locationID);
           
            return null;
        }

        public List<Oppenent> GetOpponents(int locationID)
        {
            List<object[]> data = context.GetOpponents(locationID);
            List<Oppenent> oppenents = new List<Oppenent>();

            foreach (object[] row in data)
            {
         //       oppenents.Add(new Oppenent());
            }
            return oppenents;
        }

        public List<Bystander> GetBystanders(int locationID)
        {
            List<object[]> data = context.GetBystanders(locationID);
            List<Bystander> bystanders = new List<Bystander>();

            foreach (object[] row in data)
            {
            //    bystanders.Add(new Bystander());
            }
            return bystanders;
        }

        public List<Passage> GetPassages(int locationID)
        {
            List<object[]> data = context.GetPassages(locationID);
            List<Passage> passages = new List<Passage>();

            foreach (object[] row in data)
            {
                
            }

            return passages;
        }

        public List<object[]> GetPokemon(int locationID)
        {
            return context.GetPokemon(locationID);
        }
    }
}

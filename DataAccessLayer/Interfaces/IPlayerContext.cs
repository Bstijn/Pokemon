
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IPlayerContext
    {
        void Save();

        void Load(); //misschien nog aanpassen
    }
}

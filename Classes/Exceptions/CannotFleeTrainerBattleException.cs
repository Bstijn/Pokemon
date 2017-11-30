using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes.Exceptions
{
    public class CannotFleeTrainerBattleException : Exception
    {
        public CannotFleeTrainerBattleException() : base("It is not possible to flee from a trainer battle")
        {
            
        }
    }
}

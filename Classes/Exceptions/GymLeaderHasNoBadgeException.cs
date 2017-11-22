using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Classes;

namespace Classes.Exceptions
{
    public class GymLeaderHasNoBadgeException : Exception
    {
        public GymLeaderHasNoBadgeException() : base("U already defeated this gymleader so there will not be another badge for u")// gaat dr van uit dat er niks fout is gegaan met database anders zou daar een exception gegooid moeten zijn.
        {

        }
    }
}

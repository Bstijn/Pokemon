using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Classes
{
    public class LevelUpXP
    {
        public int Level { get; }
        public int Xp { get; }

        public LevelUpXP(int level, int xp)
        {
            Level = level;
            Xp = xp;
        }
    }
}

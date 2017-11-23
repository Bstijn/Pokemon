using System;

namespace Classes
{
    public class Oppenent : Character, IItemUser
    {
        public bool Defeated { get; private set; }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }
    }
}

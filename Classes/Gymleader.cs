using System;

namespace Classes
{
    public class Gymleader : Character, IItemUser
    {
        public Boolean Defeated { get; private set; }

        public void UseItemInBattle(Consumable consumable)
        {
            throw new NotImplementedException();
        }

        public void GiveBadge(Badge badge)
        {
            throw new NotImplementedException();
        } 
    }
}

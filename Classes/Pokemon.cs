using System;
using System.Collections.Generic;

namespace Classes
{
    public class Pokemon
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public bool InParty { get; private set; }
        public int Level { get; private set; }
        public int CurrentHp { get; private set; }
        public int MaxHp { get; private set; }
        public int Xp { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }
        public int EvolveLevel { get; private set; }
        public bool Fainted { get; private set; }
        public int CaptureRate { get; private set; }

        private Type type;

        private List<Move> moves;

        public Pokemon(Type type, List<Move> moves, int id, string name, bool inParty, int level, int currentHp, int maxHp, int xp, int attack, int defense, int speed, int evolveLevel, int captureRate)
        {
            this.type = type;
            this.moves = moves;
            Id = id;
            Name = name;
            InParty = inParty;
            Level = level;
            CurrentHp = currentHp;
            MaxHp = maxHp;
            Xp = xp;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            EvolveLevel = evolveLevel;
            Fainted = true;
            CaptureRate = captureRate;
        }


        public void TakeDamage(int damage)
        {
            CurrentHp = Math.Max(CurrentHp - damage, 0);
            if (CurrentHp == 0)
            {
                Fainted = true;
            }
        }
        public void DealDamage(Move move, Pokemon defendingPokemon)
        {
            int damage = (int)((((((2 * (Convert.ToDouble(Level)) / 5) + 2) * Convert.ToDouble(move.BasePower) * (Convert.ToDouble(Attack) / Convert.ToDouble(defendingPokemon.Defense))) / 50) + 2) * GetModifier(move, defendingPokemon));
            defendingPokemon.TakeDamage(damage);
        }

        public void LevelUp()
        {
            throw new NotImplementedException();
        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }

        public Type GetType()
        {
            return type;
        }

        private double GetModifier(Move move, Pokemon defendingPokemon)
        {
            double critValue = GetCritValue(Speed);
            double randomRate = GetRandomRate();
            double stab = GetSTAB(type, move.GetType());
            double effectiveType = GetEffectiveType(move.GetType(), defendingPokemon.GetType());
            return critValue * randomRate * stab * effectiveType;
        }

        private double GetCritValue(int speed)
        {
            int T = speed / 2;
            Random random = new Random();
            int m = random.Next(0, 255);
            if (m < T)
            {
                return 1.5;
            }
            return 1;
        }

        private double GetRandomRate()
        {
            Random random = new Random();
            return (double)random.Next(85, 100) / 100;
        }

        private double GetSTAB(Type PokemonType, Type MoveType)
        {
            if (PokemonType == MoveType)
            {
                return 1.5;
            }
            return 1;
        }

        private double GetEffectiveType(Type attackType, Type defenseType)
        {
            //ToDo Ask Database for Effectiveness based on ID's
            double effectiveness = 1.5;
            return effectiveness;

        }

        public void Revive()
        {
            if (Fainted)
                CurrentHp = MaxHp / 2;
        }

        public void HealByPotion(Potion potion)
        {
            if ((CurrentHp += potion.HealAmount) > MaxHp)
            {
                CurrentHp = MaxHp;
            }
        }

        public bool TryFlee(int enemySpeed, int escapeAttempts)
        {
            int b = (enemySpeed / 4) % 256;
            int f;
            try
            {
                f = ((Speed * 32) / b) + 30 * escapeAttempts;
            }
            catch (DivideByZeroException)
            {
                return true;
            }

            if (f > 255)
            {
                return true;
            }
            Random random = new Random();
            int m = random.Next(0, 255);
            if (m < f)
            {
                return true;
            }
            return false;
        }

        public List<Move> GetMoves()
        {
            return moves;
        }

        public void Heal(int Amount)
        {
            CurrentHp = Math.Min(CurrentHp + Amount, MaxHp);
        }

        public void Revive(double percentage)
        {
            Fainted = false;
            CurrentHp = Convert.ToInt32(Math.Round(MaxHp * (percentage / 100)));
        }

    }
}

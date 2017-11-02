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

        public int CurrentHp
        {
            get { return CurrentHp; }
            private set
            {
                if (CurrentHp <= 0)
                {
                    Fainted = true;
                }
            }
        }

        public int MaxHp { get; private set; }
        public int Xp { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }
        public int EvolveLevel { get; private set; }

        public bool Fainted { get; private set; }

        private Type type;

        private List<Move> moves;

        public Pokemon(Type type, List<Move> moves, int id, string name, bool inParty, int level, int currentHp, int maxHp, int xp, int attack, int defense, int speed, int evolveLevel)
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
            Fainted = false;
        }

        public void AddMove(Move move)
        {
            if (moves.Count < 4)
            {
                moves.Add(move);
            }
        }

        public Type GetType()
        {
            return type;
        }

        public List<Move> GetMoves()
        {
            return moves;
        }

        public void TakeDamage(int dmg)
        {
            if ((CurrentHp -= dmg) <= 0)
            {

            }
        }

        public void DealDamage(Move move, Pokemon defendingPokemon)
        {
            int damage = (int)((((((2 * (Convert.ToDouble(Level)) / 5) + 2) * Convert.ToDouble(move.BasePower) * (Convert.ToDouble(Attack) / Convert.ToDouble(defendingPokemon.Defense))) / 50) + 2) * GetModifier(move, defendingPokemon));
            defendingPokemon.TakeDamage(damage);
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

        public void LevelUp()
        {
            throw new NotImplementedException();
        }

        public void Evolve()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Classes
{
    public class Pokemon
    {
        public int Id { get; private set; }
        //TODO Implement this
        public int PokedexId { get; private set; }
        public string Name { get; private set; }
        public bool InParty { get; private set; }
        public int Level { get; private set; }
        public int CurrentHp { get; private set; }
        public int MaxHp { get; private set; }
        public int Xp { get; private set; }
        public bool Fainted { get; private set; }
        public int Attack { get; private set; }
        public int Defense { get; private set; }
        public int Speed { get; private set; }
        public int EvolveLevel { get; private set; }
        public int CaptureRate { get; private set; }

        private Type type;

        private List<Move> moves;

        public Pokemon(Type type, List<Move> moves, int id, int pokedexId, string name, bool inParty, int level, int currentHp, int maxHp, int xp, bool fainted, int attack, int defense, int speed, int evolveLevel, int captureRate)
        {
            //TODO USE THIS WITH PokedexId
            this.type = type;
            this.moves = moves;
            Id = id;
            PokedexId = pokedexId;
            Name = name;
            InParty = inParty;
            Level = level;
            CurrentHp = currentHp;
            MaxHp = maxHp;
            Xp = xp;
            Fainted = fainted;
            Attack = attack;
            Defense = defense;
            Speed = speed;
            EvolveLevel = evolveLevel;
            CaptureRate = captureRate;
        }
        
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
        public int CalculateDamage(Move move, Pokemon defendingPokemon)
        {
            int damage = (int)((((((2 * (Convert.ToDouble(Level)) / 5) + 2) * Convert.ToDouble(move.BasePower) * (Convert.ToDouble(Attack) / Convert.ToDouble(defendingPokemon.Defense))) / 50) + 2) * GetModifier(move, defendingPokemon));
            MoveExecuted(move);
            return damage;
        }

        private void MoveExecuted(Move move)
        {
            foreach (Move m in moves)
            {
                if (m.Name == move.Name)
                    m.PPDown();
            }
        }
        
        public void LevelUp()
        {
            //check xp with xp to lvlupxp.
            Level++;
            if(Level >= EvolveLevel)
            {
                throw new NotImplementedException();//evolve met database
                Xp = 0;
                //update xp to lvlupxp.
            }
        }

        public void Evolve(Pokemon pokemon)
        {
            type = pokemon.type;
            moves = pokemon.moves;
            Id = pokemon.Id;
            Name = pokemon.Name;
            CurrentHp = pokemon.CurrentHp;
            MaxHp = pokemon.MaxHp;
            Attack = pokemon.Attack;
            Defense = pokemon.Defense;
            Speed = pokemon.Speed;
            EvolveLevel = pokemon.EvolveLevel;
            CaptureRate = pokemon.CaptureRate;
        }

        public Type GetType()
        {
            return type;
        }

        private double GetModifier(Move move, Pokemon defendingPokemon)//TODO: check if there is need to be changed
        {
            double critValue = GetCritValue(Speed);
            double randomRate = GetRandomRate();
            double stab = GetSTAB(type, move.GetType());
            double effectiveType = GetEffectiveType(move.GetType(), defendingPokemon.GetType());
            return critValue * randomRate * stab * effectiveType;
        }

        private double GetCritValue(int speed)//TODO: check if there is need to be changed
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

        private double GetRandomRate()//TODO: check if there is need to be changed
        {
            Random random = new Random();
            return (double)random.Next(85, 100) / 100;
        }

        private double GetSTAB(Type PokemonType, Type MoveType)//TODO: check if there is need to be changed
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


        public void Revive(int percentage)
        {
            if (Fainted)
            {
                CurrentHp = Convert.ToInt32(MaxHp * (Convert.ToDouble(percentage / 100)));
                Fainted = false;
            }

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
        /// <summary>
        /// revive used by items
        /// </summary>
        /// <param name="percentage">stands for the percentage of hp the pokemon will recover on being revived.</param>
        public void Revive(double percentage)
        {
            //Fainted = false;
            CurrentHp = Convert.ToInt32(Math.Round(MaxHp * (percentage / 100)));
        }

    }
}

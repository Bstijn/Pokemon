namespace Classes.Classes
{
    public class Battle
    {
        private Player player;
        private Character opponent;
        private Pokemon wildPokemon;
        private bool isTrainerBattle;

        public Battle(Player player, Character opponent)
        {
            this.player = player;
            this.opponent = opponent;
            isTrainerBattle = true;
        }

        public Battle(Player player, Pokemon wildPokemon)
        {
            this.player = player;
            this.wildPokemon = wildPokemon;
            isTrainerBattle = false;
        }


    }
}

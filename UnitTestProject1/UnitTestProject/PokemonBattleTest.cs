using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class PokemonBattleTest
    {
        [TestMethod]
        public void DealDmgTest()//not an accurate test needs to check all factors not just if it hit.
        {
            Pokemon pokemon1 = new Pokemon(new Type(1, "Fire"), new List<Move>() { new Move(1, "Fireball", 20, 20, 80, "fiyaaah", false, 100, 1) }, 1, "vuurdude", true, 5, 100, 100, 0, 10, 10, 10, 20, 10);
            Pokemon pokemon2 = new Pokemon(new Type(2, "Water"), new List<Move>() { new Move(1, "Waterball", 20, 20, 80, "wataaah", false, 100, 1) }, 1, "waterdude", true, 5, 100, 100, 0, 10, 10, 10, 20, 10);

            pokemon1.DealDamage(pokemon1.GetMoves()[0], pokemon2);

            Assert.AreNotEqual(100, pokemon2.CurrentHp);
            
        }

        [TestMethod]
        public void FleeFromPokemonTest()
        {
            Player player = new Player("Henk", 0, "the only gender out there", 100000, 1, 1, new Cave(1, 1, 1, "", null, 1, 1, 1, null), null, null, 0, 0);
            Pokemon pokemon1 = new Pokemon(new Type(1, "Fire"), new List<Move>() { new Move(1, "Fireball", 20, 20, 80, "fiyaaah", false, 100, 1) }, 1, "vuurdude", true, 5, 100, 100, 0, 10, 10, 10, 20, 10);
            Pokemon pokemon2 = new Pokemon(null, null, 0, "", true, 5, 100, 100, 0, 5, 5, 5, 20, 1);
            Assert.IsTrue(pokemon1.TryFlee(pokemon2.Speed, 0), "fleeing is niet succesvol");
        }
    }
}

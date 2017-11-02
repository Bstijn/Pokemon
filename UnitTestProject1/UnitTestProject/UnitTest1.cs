using Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void DealAndTakeDamageTest()
        {
            Pokemon pokemon1 = new Pokemon(new Type(1, "Fire"), new List<Move>() { new Move(1, "Fireball", 20, 20, 80, "fiyaaah", false, 100, 1) }, 1, "vuurdude", true, 5, 100, 100, 0, 10, 10, 10, 20);
            Pokemon pokemon2 = new Pokemon(new Type(2, "Water"), new List<Move>() { new Move(1, "Waterball", 20, 20, 80, "wataaah", false, 100, 1) }, 1, "waterdude", true, 5, 100, 100, 0, 10, 10, 10, 20);

            pokemon1.DealDamage(pokemon1.GetMoves()[0], pokemon2);

            Assert.AreNotEqual(100, pokemon2.CurrentHp);
        }


    }
}

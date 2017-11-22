using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Exceptions;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class InterfaceItemUserTest
    {
        [TestMethod]
        public void UsePotionTest()
        {
            //assemble
            List<Item> items = new List<Item>() { new Potion(1, "pot", 20, "pot", 30) };
            List<Pokemon> pokemon = new List<Pokemon>() { new Pokemon(null, null, 1, "gerald", true, 1, 1, 20, 0, 0, 0, 0, 0, 0, false) };
            Player player = new Player("ads", 1, "", 0, 0, 0, null, items, pokemon, 0, 0,null);
            //act
            player.UseItem(pokemon[0], items[0] as Consumable);
            //assert
            Assert.AreEqual(pokemon[0].CurrentHp, 20, "hp klopt niet gaat wellicht erboven of eronder");
            Assert.AreEqual(items.Count, 0, "items hoort nul te zijn item is niet goed van lijst verwijdert");
        }
        [TestMethod]
        public void UseReviveTest()
        {
            List<Item> items = new List<Item>() { new Revive(1, "pot", 20, "pot", 30) };
            List<Pokemon> pokemon = new List<Pokemon>() { new Pokemon(null, null, 1, "gerald", true, 1, 0, 100, 0, 0, 0, 0, 0, 0, true) };
            Player player = new Player("ads", 1, "", 0, 0, 0, null, items, pokemon, 0, 0,null);
            player.UseItem(pokemon[0], items[0] as Revive);

            Assert.AreEqual(items.Count, 0, "items hoort nul te zijn item is niet goed van lijst verwijdert");
            Assert.AreEqual(30, pokemon[0].CurrentHp, "hp is niet correct");
            Assert.AreEqual(false, pokemon[0].Fainted, "boolean fainted didnt change");
        }
    }
}

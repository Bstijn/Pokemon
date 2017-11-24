using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Exceptions;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class buyselltests
    {
        [TestMethod]
        public void sellTest()
        {
            Player player = new Player(null, 0, null,0, 0, 0, null, new List<Item>(), new List<Pokemon>(), 0, 0);
            Pokeball pokeball = new Pokeball(1, "pokeball", 300, "het is een pokeball", 00);
            player.GiveItem(pokeball);
            player.SellItem(pokeball,1);
            //assert
            Assert.AreEqual(300, player.Money);
        }

        [TestMethod]
        public void BuyTest()
        {
            Player player = new Player(null,0,null,300,0,0,null,new List<Item>(),new List<Pokemon>(),0,0);
            Pokeball pokeball = new Pokeball(1, "pokeball", 200, "het is een pokeball", 00);
            player.BuyItem(pokeball, 1);
            Assert.AreEqual(100, player.Money);
            Assert.AreEqual(1, player.Inventory.Count);
                

        }
    }
}

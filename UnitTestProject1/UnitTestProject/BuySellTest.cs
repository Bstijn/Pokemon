using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Exceptions;

namespace UnitTestProject
{
    [TestClass]
    public class BuySellTest
    {
        [TestMethod]
        public void PlayerBuyTest()
        {
            Player player = new Player();
            player.GiveMoney(500);
            //act
            player.BuyItem(new Pokeball(1, "normal pokeball", 100, "ispokeball", 30),3);
            //assert
            Assert.AreEqual(200, player.Money,"checking if playermoney");
            Assert.AreEqual(3, player.Inventory.Count, "Checking if amount is right");

            
        }
    }
}

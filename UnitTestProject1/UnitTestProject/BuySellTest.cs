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
            player.Inventory.Add(new Pokeball() {Cost = 300, });
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTestProject
{
    [TestClass]
    public class PassageTest
    {
        [TestMethod]
        public void PlayerChangeLocationTest()
        {
            //assemble
            Route route = new Route(1, 1, 1, "", null, 0, 0, 0, null);
            Player player = new Player("", 1, "", 1, 1, 1, null, null, null, 0, 0, null);
            //act
            player.GoToLocation(new Passage(1, 1, 1, 20, 20, route));
            //assert
            Assert.AreNotEqual(player.CurrentLocation, null, "locatie is niet verandert.");
            Assert.AreEqual(player.CurrentLocation, route, "locatie is niet goed verandert.");
            Assert.AreEqual(20, player.PosX,"posx niet verandert.");
            Assert.AreEqual(20, player.PosY,"posy niet verandert.");

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using Classes.Exceptions;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class GymLeaderTest
    {
        /// <summary>
        /// test shows that the defeated boolean will change and inventory will not contain a badge anymore.
        /// </summary>
        [TestMethod]
        public void GymLeaderLoseTest()
        {
            //assemble
            Badge actualBadge =  new Badge(1, "fireBadge", "the badge of the fire gym");
            List<Item> items = new List<Item>() {actualBadge};
            Gymleader GL = new Gymleader("leader", 1, "", 0, 0, 0, null, items, null, false);
            //act
            Badge winnersbadge = GL.Lose();
            //assert
            Assert.AreEqual(actualBadge, winnersbadge,"the winner did not get the badge");
            Assert.AreEqual(true, GL.Defeated,"GL didnt get defeated after losing");
            Assert.AreEqual(0,GL.Inventory.Count, "badge is should not be in GL inventory");

            
        }

        [TestMethod]
        public void GymLeaderExceptionTest()
        {
            Badge actualBadge = new Badge(1, "fireBadge", "the badge of the fire gym");
            List<Item> items = new List<Item>() { };
            Gymleader GL = new Gymleader("leader", 1, "", 0, 0, 0, null, items, null, false);
            //act
            try
            {
                Badge winnersbadge = GL.Lose();
            }
            catch (GymLeaderHasNoBadgeException)
            {
                return;
            }
            catch (Exception)
            {
                Assert.Fail("other exceptions were thrown.");
            }
            Assert.Fail("no exceptions are thrown.");
            
            
        }
    }
}

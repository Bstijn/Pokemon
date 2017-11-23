using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;
using System.Collections.Generic;

namespace UnitTestProject
{
    [TestClass]
    public class NurseTest
    {
        [TestMethod]
        public void NurseHealTest()
        {
            //assemble
            Nurse nurse = new Nurse("ME NURSE", 1, "", 0, 0, 0, null, null, null);
            List<Pokemon> pokemon = new List<Pokemon>() {new Pokemon(null,null,0,"",true,1,0,30,0,0,0,0,0,0,true),
                                                         new Pokemon(null,null,0,"",true,0,15,30,0,0,0,0,0,0,false)};
            //act
            nurse.Heal(pokemon);
            //assert
            Assert.AreEqual(false, pokemon[0].Fainted, "first pokemon shouldnt be fainted");
            Assert.AreEqual(false, pokemon[1].Fainted, "second pokemon shouldnt be fainted");
            Assert.AreEqual(pokemon[0].MaxHp, pokemon[0].CurrentHp,"first pokemon should have equal to maxhp");
            Assert.AreEqual(pokemon[1].MaxHp, pokemon[1].CurrentHp,"first pokemon should have equal to maxhp");


        }
    }
}

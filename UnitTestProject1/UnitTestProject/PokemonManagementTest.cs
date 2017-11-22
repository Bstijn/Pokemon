using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Classes;

namespace UnitTestProject
{
    [TestClass]
    public class PokemonManagementTest
    {
        [TestMethod]
        public void PokemonPartySwitchTest()
        {
            Pokemon switchpokemon1 = new Pokemon(null, null, 0, "", true, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);
            Pokemon switchpokemon2 = new Pokemon(null, null, 0, "", true, 0, 0, 0, 0, 0, 0, 0, 0, 0, false); ;
            List<Pokemon> pokemons = new List<Pokemon>() { switchpokemon1, new Pokemon(null, null, 0, "", true, 0, 0, 0, 0, 0, 0, 0, 0, 0, false) ,switchpokemon2, new Pokemon(null, null, 0, "", true, 0, 0, 0, 0, 0, 0, 0, 0, 0, false) };
            Player player = new Player("", 0, "", 0, 0, 0, null, null, pokemons, 0, 0,null);
            //act
            player.ManageParty(switchpokemon1, switchpokemon2);
            //assert
            Assert.AreEqual(0, pokemons.IndexOf(switchpokemon2));
            Assert.AreEqual(2, pokemons.IndexOf(switchpokemon1));
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Classes;

namespace UnitTestProject
{
    /// <summary>
    /// Summary description for UseItemInBattleTest
    /// </summary>
    [TestClass]
    public class BattleTest
    {
        
        [TestMethod]
        public void UseItemInBattle()
        {
            List<Pokemon> pokemons = new List<Pokemon>();
            pokemons.Add(new Pokemon(null,null,1,"Pikachu",true,1,1,2,1,1,1,1,3,5));
            Pokemon pokemon = new Pokemon(null,null,1,"Raichu",true,1,2,4,6,2,6,2,6,20);
            Player player = new Player("Henk",1,"Male",9999,1,1,null,null,pokemons,1,1);
            Battle battle = new Battle(player,pokemon);
            battle.UseItem()
        }
    }
}

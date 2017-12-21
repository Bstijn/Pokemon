using UnityEngine;
using Classes;
using CType = Classes.Type;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Assets.Scripts;

public class WildBattleTrigger : MonoBehaviour {

    public float EncounterRate;
    Area location;

    //DB -> Pokémon
    private void Start()
    {
        //EncounterRate = GameController.instance.encounterRate;
        //location = FindObjectOfType<Player>().GetCurrentLocation() as Area;
    }


    private void Awake()
    {
        //Load Pokémon
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int roll = Random.Range(0, 100);
        if (roll < EncounterRate)
        {
            other.GetComponent<Player>().inBattle = true;
            CreateBattle();
        }
        else
        {
            Debug.Log(roll + " No battle");
        }
    }

    private void CreateBattle()
    {
        var type1 = new CType(1, "Fire");
        var type2 = new CType(2, "Water");
        var type3 = new CType(3, "Grass");

        var move1 = new Move(1, "Fire attack", 15, 15, 100, "A fire attack, duhh", false, 60, 1, type1);
        var move3 = new Move(3, "grass attack", 15, 15, 100, "A grass attack, duhh", false, 60, 1, type3);
        var move4 = new Move(4, "Fire!!!!", 15, 15, 80, "A fire attack, duhh", false, 80, 1, type1);
        var move5 = new Move(5, "Water!!!!", 15, 15, 80, "A water attack, duhh", false, 80, 1, type2);
        var move6 = new Move(6, "grass!!!!", 15, 15, 80, "A grass attack, duhh", false, 80, 1, type3);

        var movelist1 = new List<Move> { move1, move4, move3 };
        var movelist2 = new List<Move> { move5, move6 };

        var wildpokemon = new Pokemon(type3, movelist2, 110, 1, "Cutecumber", false, 10, 100, 100, 5, false, 10, 10, 10, 50, 50);
        var playerpokemon = new Pokemon(type1, movelist1, 15, 4, "Dubbleup", false, 11, 80, 100, 100, false, 15, 11, 9, 50, 10);

        var player = FindObjectOfType<Player>().player;
        player.Pokemons.Add(playerpokemon);

        SceneManager.LoadScene("Battle", LoadSceneMode.Additive);
        FindObjectOfType<BattleConroller>().LoadBattle(player, wildpokemon);
    }
}

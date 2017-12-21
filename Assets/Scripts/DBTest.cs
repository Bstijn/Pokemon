using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Classes;
using Classes.Repos;

public class DBTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        CharacterRepository repo = new CharacterRepository();
        List<Pokemon> pokemons = repo.GetPokemonFromParty(6);

        foreach (Pokemon pokemon in pokemons)
        {
            Debug.Log(pokemon.Name);
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}

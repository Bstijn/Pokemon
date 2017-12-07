using UnityEngine;
using Classes;

public class WildBattleTrigger : MonoBehaviour {

    public float EncounterRate;
    Area location;
    //DB -> Pokémon

    private void Awake()
    {
        EncounterRate = GameController.instance.encounterRate;
        location = FindObjectOfType<Player>().GetCurrentLocation() as Area;
        //Load Pokémon
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (location.EncounterPokemon())
        {
            Pokemon pokemon = location.GenerateBattle();
            //SceneManager.LoadScene(battle, pokemon);
            Debug.Log("Encountered Pokemon: "+ pokemon.Name);
        }
    }
}

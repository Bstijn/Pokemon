using UnityEngine;

public class WildBattleTrigger : MonoBehaviour {

    public float EncounterRate;
    System.Random rando;

    //DB -> Pokémon

    private void Awake()
    {
        rando = new System.Random();
        EncounterRate = GameController.instance.encounterRate;
        //Load Pokémon
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (rando.Next(0, 100) < EncounterRate)
        {
            //Get Pokemon
            //Start Battle

            Debug.Log("Encountered Pokemon: "/*random pokemon*/);
        }
    }
}

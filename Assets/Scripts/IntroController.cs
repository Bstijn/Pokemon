using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroController : MonoBehaviour
{
    private static List<string> dialogues = new List<string>() {"SKRRRRRRR", "PA PA PA PA No Sauce" };
    private int currentdialogue = 0;
    [SerializeField]
    private Text dialogue;
    [SerializeField]
    private GameObject dialogueUI;
    [SerializeField]
    private GameObject BoyOrGirlUI;
    private string Gender;
    void Start()
    {
        dialogue.text = dialogues[currentdialogue];
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
        {
            currentdialogue++;
            if (dialogues.Count > currentdialogue)
            {
                dialogue.text = dialogues[currentdialogue];
            }
            else
            {
                dialogueUI.SetActive(false);
                BoyOrGirlUI.SetActive(true);
            }
        }
    }

    private void ChooseGender(string gender)
    {
        this.Gender = gender;
    }
    private void OpenPokemonSelection()
    {

    }

    private void ChoosePokemon(string name)
    {

    }
}

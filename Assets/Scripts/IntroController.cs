using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Classes;
using Classes.Repos;
using UnityEngine.SceneManagement;



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
    [SerializeField]
    private GameObject PokemonChoiceUI;
    [SerializeField]
    private GameObject professor;
    [SerializeField]
    private GameObject NameUI;
    [SerializeField]
    private Text nameText;
    private string name = null;
    private string gender = null;
    private int pokemonId;
    private CharacterRepository dal;
    void Start()
    {
        dal = new CharacterRepository();
        dialogue.text = dialogues[currentdialogue];
    }

    void Update()
    {
        
        if (name == null)
        {
            ShowNameDialogue();
            
        }
        else
        {
            IntroDialogue();
        }
    }

    private void ShowNameDialogue()
    {
        NameUI.SetActive(true);
    }

    public void ChooseName()
    {
        
        this.name = nameText.text;
        NameUI.SetActive(false);
        dialogueUI.SetActive(true);
        professor.SetActive(true);
    }
    private void IntroDialogue()
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
                dialogue.text = "Are you a boy or a grill";
                dialogue.fontSize = 28;
                BoyOrGirlUI.SetActive(true);
            }
        }
    }

    public void ChooseGender(string gender)
    {
        this.gender = gender;
        BoyOrGirlUI.SetActive(false);
        dialogueUI.SetActive(false);
        professor.SetActive(false);
        OpenPokemonSelection();
    }
    private void OpenPokemonSelection()
    {
        PokemonChoiceUI.SetActive(true);
    }

    public void ChoosePokemon(int Id)
    {
        pokemonId = Id;
        SaveChoices();
    }

    private void SaveChoices()
    {
        Debug.Log("we zijn hier i guess");
        dal.InsertIntro(pokemonId, name, gender);
        //TODO IMPLEMENT IN DB
        StartGame();
    }
    private void StartGame()
    {
        SceneManager.LoadScene("Park Town");
    }
}

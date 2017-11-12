using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BattleConroller : MonoBehaviour
    {
        [SerializeField] private Sprite[] AttackTypeSprites;
        [SerializeField] private GameObject MainMenu;
        [SerializeField] private GameObject InfoAttackMenu;

        private const string Power = "100";
        private const string Accuracy = "80";
        private const string Description = "ya ya yippee yippee ya ya yee we lopen op het strand en dansen blootsvoets hand in hand we zingen ya ya yippee yippee ya ya yee en onze stem weerklinkt over de golven zingen ya ya yippee yippee ya ya yee";

        #region ButtonHandlers
        public void OnAttackMenuButtonPress(GameObject attackMenu)
        {
            attackMenu.SetActive(true);
            MainMenu.SetActive(false);
            for (var i = 0; i < 4; i++)
            {
                attackMenu.transform.Find("MoveButton" + i).gameObject.GetComponent<Image>().sprite = AttackTypeSprites[0];
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("Name").gameObject.GetComponent<Text>.text = movename;
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("PP").gameObject.GetComponent<Text>.text = ppcurrent + " / " + ppmax;
                //if pp < 50%
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("PP").gameObject.GetComponent<Text>().color = new Color(189f/255f, 129f/255f, 0);
                //if pp < 25%
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("PP").gameObject.GetComponent<Text>().color = new Color(193f/255f, 9f/255f, 0);
                //else 
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("PP").gameObject.GetComponent<Text>().color = new Color(0, 0, 0);
            }
        }

        public void OnBackToMainMenuButtonPress(GameObject currentMenu)
        {
            MainMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

        public void OnUseMoveButtonPress(int moveNumber)
        {
            //do move things
        }
        
        public void OnHighlightButton(int moveNumber)
        {
            InfoAttackMenu.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = Description;
            InfoAttackMenu.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + Power;
            InfoAttackMenu.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + Accuracy;
        }

        public void OnShowPokemonMenuButtonPress(GameObject pokemonMenu)  
        {
            pokemonMenu.SetActive(true);
            MainMenu.SetActive(false);
        }

        public void OnShowBackPackMenuButtonPress(GameObject backpackMenu)
        {
            backpackMenu.SetActive(true);
            MainMenu.SetActive(false);
        }

        public void OnTryFleeButtonPress()
        {
            
        }
        #endregion
    }
}

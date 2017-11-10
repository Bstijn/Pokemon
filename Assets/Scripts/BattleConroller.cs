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
            }
        }

        public void OnBackToMainMenuButtonPress(GameObject currentMenu)
        {
            MainMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

        public void OnUseMoveButtonPress(int moveNumber)
        {
            
        }

        public void OnHighlightButton(int moveNumber)
        {
            InfoAttackMenu.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = Description;
            InfoAttackMenu.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + Power;
            InfoAttackMenu.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + Accuracy;
        }
        #endregion
    }
}

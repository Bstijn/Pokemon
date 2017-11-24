using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Classes;

namespace Assets.Scripts
{
    public class BattleConroller : MonoBehaviour
    {
        [SerializeField] private Sprite[] AttackTypeSprites;
        [SerializeField] private GameObject MainMenu;
        [SerializeField] private GameObject InfoAttackMenu;
        [SerializeField] private GameObject PokemonMenu;
        [SerializeField] private GameObject ItemContent;
        [SerializeField] private GameObject ItemButton;

        private const string Power = "100";
        private const string Accuracy = "80";
        private const string Description = "ya ya yippee yippee ya ya yee we lopen op het strand en dansen blootsvoets hand in hand we zingen ya ya yippee yippee ya ya yee en onze stem weerklinkt over de golven zingen ya ya yippee yippee ya ya yee";
        
        private const string PokemonName = "Pokemonname";
        private const int PokemonCurrentHp = 15;
        private const int PokemonMaxHp = 20;
        
        #region ButtonHandlers
        public void OnAttackMenuButtonPress(GameObject attackMenu)
        {

            for (var i = 0; i < 4; i++)
            {
                attackMenu.transform.Find("MoveButton" + i).gameObject.GetComponent<Image>().sprite = AttackTypeSprites[0];
                //TODO
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

        public void HideObject(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }

        public void ShowObject(GameObject gameObject)
        {
            gameObject.SetActive(true);
        }
        
        public void OnBackToMainMenuButtonPress(GameObject currentMenu)
        {
            MainMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

        public void OnUseMoveButtonPress(int moveNumber)
        {
            //TODO
            //do things
        }
        
        public void OnHighlightButton(int moveNumber)
        {
            InfoAttackMenu.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = Description;//TODO
            InfoAttackMenu.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + Power;//TODO
            InfoAttackMenu.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + Accuracy;//TODO
        }

        public void OnShowPokemonMenuButtonPress(GameObject pokemonMenu)  
        {
            pokemonMenu.SetActive(true);
            MainMenu.SetActive(false);
            LoadPokemonMenuInfo(pokemonMenu);
        }

        public void OnShowBackPackMenuButtonPress(GameObject backpackMenu)
        {
            backpackMenu.SetActive(true);
            MainMenu.SetActive(false);
        }

        public void OnTryFleeButtonPress()
        {
         //TODO
        }
        #endregion
            
        public void LoadPokemonMenuInfo(GameObject pokemonMenu)
        {
            for (var i = 0; i < 6; i++)
            {
                //TODO
                StartCoroutine("SwitchIconSprites", i);
            }
        }

        public void ShowItems()
        {
            foreach (Transform i in ItemContent.transform)
            {
                Destroy(i.gameObject);
            }
            var itemList = new List<Item>();//TODO
            ItemContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 300 + 100 * itemList.Count);
            for (var i = 0; i < itemList.Count; i++)
            {
                var button = Instantiate(ItemButton, ItemContent.transform);
                var y = -200 - i * 100;
                int x;
                if (IsEven(i))
                {
                    x = -400;
                }
                else
                {
                    x = 400;
                }
                button.GetComponent<RectTransform>().anchoredPosition3D = new Vector3(x, y, 0);
                var sprites = Resources.LoadAll<Sprite>("ItemIcon/item" + itemList[i].Id.ToString("000"));//TODO
                button.transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprites[0];
                button.transform.Find("Text").gameObject.GetComponent<Text>().text = "DummyText";//TODO
            }
        }

        private bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        public IEnumerator SwitchIconSprites(int counter)
        {
            var count = 0;
            var sprites = Resources.LoadAll<Sprite>("PokemonIcons/icon" + (counter + 1).ToString("000"));
            yield return sprites;
            while (PokemonMenu.activeSelf)
            { 
                PokemonMenu.transform.Find("PokemonButton" + counter).transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprites[count];
                count++;
                count = count % 2;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}

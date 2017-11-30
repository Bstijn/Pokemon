using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Classes;

namespace Assets.Scripts
{
    public class BattleConroller : MonoBehaviour
    {
        [SerializeField] private Sprite[] _attackTypeSprites;
        [SerializeField] private GameObject _mainMenu;
        [SerializeField] private GameObject _infoAttackMenu;
        [SerializeField] private GameObject _pokemonMenu;
        [SerializeField] private GameObject _itemContent;
        [SerializeField] private GameObject _itemButton;
        private Battle _battle;

        private const string Power = "100";
        private const string Accuracy = "80";
        private const string Description = "ya ya yippee yippee ya ya yee we lopen op het strand en dansen blootsvoets hand in hand we zingen ya ya yippee yippee ya ya yee en onze stem weerklinkt over de golven zingen ya ya yippee yippee ya ya yee";
        
        private const string PokemonName = "Pokemonname";
        private const int PokemonCurrentHp = 15;
        private const int PokemonMaxHp = 20;

        public void CreateNewBattle(Battle battle)
        {
            _battle = battle;
        }
        
        #region ButtonHandlers
        public void OnAttackMenuButtonPress(GameObject attackMenu)
        {

            for (var i = 0; i < 4; i++)
            {
                attackMenu.transform.Find("MoveButton" + i).gameObject.GetComponent<Image>().sprite = _attackTypeSprites[0];
                //TODO set color moves
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("Name").gameObject.GetComponent<Text>().text = ;
                //attackMenu.transform.Find("MoveButton" + i).gameObject.transform.Find("PP").gameObject.GetComponent<Text>().text = ppcurrent + " / " + ppmax;
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
            _mainMenu.SetActive(true);
            currentMenu.SetActive(false);
        }

        public void OnUseMoveButtonPress(int moveNumber)
        {
            //TODO do move stuff
            //do things
        }
        
        public void OnHighlightButton(int moveNumber)
        {
            //TODO pokemonmove waardes pakken
            _infoAttackMenu.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = Description;
            _infoAttackMenu.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + Power;
            _infoAttackMenu.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + Accuracy;
        }

        public void OnShowPokemonMenuButtonPress(GameObject pokemonMenu)  
        {
            pokemonMenu.SetActive(true);
            _mainMenu.SetActive(false);
            LoadPokemonMenuInfo(pokemonMenu);
        }

        public void OnShowBackPackMenuButtonPress(GameObject backpackMenu)
        {
            backpackMenu.SetActive(true);
            _mainMenu.SetActive(false);
        }

        public void OnTryFleeButtonPress()
        {
         //TODO try flee
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
            foreach (Transform i in _itemContent.transform)
            {
                Destroy(i.gameObject);
            }
            var itemList = new List<Item>();//TODO
            _itemContent.transform.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 300 + 100 * itemList.Count);
            for (var i = 0; i < itemList.Count; i++)
            {
                var button = Instantiate(_itemButton, _itemContent.transform);
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
            while (_pokemonMenu.activeSelf)
            { 
                _pokemonMenu.transform.Find("PokemonButton" + counter).transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprites[count];
                count++;
                count = count % 2;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}

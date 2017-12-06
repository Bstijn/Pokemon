using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Classes;
using Classes.Exceptions;
using UnityEngine.SceneManagement;

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
        [SerializeField] private GameObject _textPanel;
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
                var button = attackMenu.transform.Find("MoveButton" + i).gameObject;
                try
                {
                    var move = _battle.PlayerPokemon.GetMoves()[i];
                    button.GetComponent<Image>().sprite = _attackTypeSprites[0];
                    button.transform.Find("Name").gameObject
                        .GetComponent<Text>().text = move.Name;
                    button.transform.Find("PP").gameObject.GetComponent<Text>().text = move.CurrentPP + " / " + move.MaxPP;
                    var percentage = move.CurrentPP / (float)move.MaxPP;
                    if (percentage < 0.5)
                    {
                        button.transform.Find("PP").gameObject.GetComponent<Text>().color = new Color(189f / 255f, 129f / 255f, 0);
                    }
                    else if (percentage < 0.25)
                    {
                        button.transform.Find("PP").gameObject
                            .GetComponent<Text>().color = new Color(193f / 255f, 9f / 255f, 0);
                    }
                    else
                    {
                        button.transform.Find("PP").gameObject.GetComponent<Text>().color = new Color(0, 0, 0);
                    }
                    button.SetActive(true);
                }
                catch (IndexOutOfRangeException)
                {
                    button.SetActive(false);
                }

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
        }
        
        public void OnHighlightButton(int moveNumber)
        {
            //TODO pokemonmove waardes pakken
            _infoAttackMenu.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = Description;
            _infoAttackMenu.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + Power;
            _infoAttackMenu.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + Accuracy;
        }

        public void OnTryFleeButtonPress()
        {
            var text = _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text;
            bool flee;
            try
            {
                flee = _battle.Flee(_battle.PlayerPokemon);
                text = flee ? "You escaped the battle succesfully!" : "You could did not escape!";
            }
            catch (CannotFleeTrainerBattleException)
            {
                flee = false;
                text = "You cannot flee from a trainer battle!";
            }
            StartCoroutine("FleeAnimation", flee);
        }

        private IEnumerator FleeAnimation(bool flee)
        {
            var pressed = false;
            _mainMenu.SetActive(false);
            _textPanel.SetActive(true);
            _textPanel.transform.Find("ArrowPanel").gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            _textPanel.transform.Find("ArrowPanel").gameObject.SetActive(true);
            while (!pressed)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
                {
                    pressed = true;
                }
                yield return null;
            }
            if (flee)
            {
                SceneManager.UnloadSceneAsync("Battle");
            }
            else
            {
                //TODO GO TO ENEMY MOVE
                //flee failed, enemy can do move
            }

        }
        #endregion
            
        public void LoadPokemonMenuInfo(GameObject pokemonMenu)
        {
            for (var i = 0; i < 6; i++)
            {
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
                if (i % 2 == 0)
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

        private IEnumerator SwitchIconSprites(int counter)
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

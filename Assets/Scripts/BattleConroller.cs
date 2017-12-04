using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;
using Classes;
using Classes.Exceptions;
using NUnit.Framework.Interfaces;
using UnityEngine.SceneManagement;
using Player = Classes.Player;

namespace Assets.Scripts
{
    public class BattleConroller : MonoBehaviour
    {
        [SerializeField] private Sprite[] _attackTypeSprites;
        [SerializeField] private GameObject _mainPanel;
        [SerializeField] private GameObject _infoAttackPanel;
        [SerializeField] private GameObject _pokemonPanel;
        [SerializeField] private GameObject _itemContent;
        [SerializeField] private GameObject _itemButton;
        [SerializeField] private GameObject _textPanel;
        [SerializeField] private GameObject _EnemyPanel;
        [SerializeField] private GameObject _PlayerPanel;

        private Battle _battle;

        public void CreateNewBattle(Battle battle)
        {
            _battle = battle;
            SetPokemonInfo(_PlayerPanel, _battle.PlayerPokemon);
            SetPokemonInfo(_EnemyPanel, _battle.WildPokemon ?? _battle.OpponentPokemon);         
            SetPokemonSprite(_PlayerPanel, "PokemonBack/back" + _battle.PlayerPokemon.PokedexId.ToString("000"));
            if (_battle.WildPokemon == null)
            {
                SetPokemonSprite(_EnemyPanel, "PokemonFront/front" + _battle.OpponentPokemon.PokedexId.ToString("000"));
            }
            else
            {
                SetPokemonSprite(_EnemyPanel, "PokemonFront/front" + _battle.WildPokemon.PokedexId.ToString("000"));
            }
        }

        private void SetPokemonSprite(GameObject panel, string uri)
        {
            panel.transform.Find("Base").transform.Find("Image").gameObject.GetComponent<Image>().sprite =
                Resources.LoadAll<Sprite>(uri)[0];
        }

        private void SetPokemonInfo(GameObject panel, Pokemon pokemon)
        {
            panel.transform.Find("Stats").transform.Find("NameText").gameObject.GetComponent<Text>().text =
                pokemon.Name;
            panel.transform.Find("Stats").transform.Find("LevelText").gameObject.GetComponent<Text>().text =
                "Lv " + pokemon.Level;
            UpdateHpUi(panel, pokemon);
        }

        private void UpdateHpUi(GameObject panel, Pokemon pokemon)
        {
            panel.transform.Find("Stats").transform.Find("HpBar").gameObject.GetComponent<Scrollbar>().size =
                pokemon.CurrentHp / (float) pokemon.MaxHp;
            panel.transform.Find("Stats").transform.Find("HpText").gameObject.GetComponent<Text>().text =
                pokemon.CurrentHp + "/" + pokemon.MaxHp;
        }
        
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
            _mainPanel.SetActive(true);
            currentMenu.SetActive(false);
        }

        public void OnUseMoveButtonPress(int moveNumber)
        {
            StartCoroutine(Turn(moveNumber));
        }

        private IEnumerator Turn(int playerMoveNumber)
        {
            //TODO TURNc
            var first = _battle.WildPokemon == null ? _battle.FirstAttack(_battle.PlayerPokemon, _battle.WildPokemon) : _battle.FirstAttack(_battle.PlayerPokemon, _battle.OpponentPokemon);
            var second = _battle.PlayerPokemon;
            if (first.Id == _battle.PlayerPokemon.Id)
            {
                second = _battle.WildPokemon ?? _battle.OpponentPokemon;
            }

            yield return UseAttack(first, second, first.GetMoves()[playerMoveNumber]);
            if (second.Fainted)
            {
                
            }
        }

        public IEnumerator UseAttack(Pokemon attackPokemon, Pokemon defendPokemon, Move move)
        {
            _textPanel.SetActive(true);
            _mainPanel.SetActive(false);
            _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                attackPokemon.Name + " used " + move.Name;
            yield return new WaitForSeconds(1);
            var damage = _battle.Attack(attackPokemon, defendPokemon, move);
            _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                move.Name + " did " + damage + "damage";
            yield return new WaitForSeconds(1);

        }

        public void OnHighlightButton(int moveNumber)
        {
            _infoAttackPanel.transform.Find("DescriptionText").gameObject.GetComponent<Text>().text = _battle.PlayerPokemon.GetMoves()[moveNumber].Description;
            _infoAttackPanel.transform.Find("PowerText").gameObject.GetComponent<Text>().text = "Power: " + _battle.PlayerPokemon.GetMoves()[moveNumber].BasePower;
            _infoAttackPanel.transform.Find("AccuracyText").gameObject.GetComponent<Text>().text = "Accuracy: " + _battle.PlayerPokemon.GetMoves()[moveNumber].Accuracy;
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
            _mainPanel.SetActive(false);
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
                //TODO CHECK FAINTED!
                //flee failed, enemy can do move
            }

        }
            
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
                var sprites = Resources.LoadAll<Sprite>("ItemIcon/item" + itemList[i].Id.ToString("000"));//TODO items
                button.transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprites[0];
                button.transform.Find("Text").gameObject.GetComponent<Text>().text = "DummyText";
            }
        }

        private IEnumerator SwitchIconSprites(int counter)
        {
            var count = 0;
            var sprites = Resources.LoadAll<Sprite>("PokemonIcons/icon" + (counter + 1).ToString("000"));
            yield return sprites;
            while (_pokemonPanel.activeSelf)
            { 
                _pokemonPanel.transform.Find("PokemonButton" + counter).transform.Find("Image").gameObject.GetComponent<Image>().sprite = sprites[count];
                count++;
                count = count % 2;
                yield return new WaitForSeconds(0.25f);
            }
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using UnityEngine;
using UnityEngine.UI;
using Classes;
using Classes.Exceptions;
using UnityEngine.Networking.NetworkSystem;
using UnityEngine.SceneManagement;
using CPlayer = Classes.Player;
using CType = Classes.Type;

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

        public void Start()
        {
            var type1 = new CType(1, "Fire");
            var type2 = new CType(2, "Water");
            var type3 = new CType(3, "Grass");

            var move1 = new Move(1, "Fire attack", 15, 15, 100, "A fire attack, duhh", false, 60, 1, type1);
            var move2 = new Move(2, "Water attack", 15, 15, 100, "A water attack, duhh", false, 60, 1, type2);
            var move3 = new Move(3, "grass attack", 15, 15, 100, "A grass attack, duhh", false, 60, 1, type3);
            var move4 = new Move(4, "Fire!!!!", 15, 15, 80, "A fire attack, duhh", false, 80, 1, type1);
            var move5 = new Move(5, "Water!!!!", 15, 15, 80, "A water attack, duhh", false, 80, 1, type2);
            var move6 = new Move(6, "grass!!!!", 15, 15, 80, "A grass attack, duhh", false, 80, 1, type3);

            var movelist1 = new List<Move> {move1, move4, move2, move5};
            var movelist2 = new List<Move>{move3, move6};

            var wildpokemon = new Pokemon(type3, movelist2, 110, 7, "WOOOW", false, 10, 100, 100, 5, false, 10, 10, 10, 50, 50);
            var playerpokemon = new Pokemon(type1, movelist1, 15, 1, "Doubleup", false, 11, 80, 100, 100, false, 15, 11, 9, 50, 10);

            var player = new CPlayer("Ayyayayay", 1, "Male", 1000, 5, 5, null, null, new List<Pokemon>{playerpokemon}, 50, 5, null);
            var battle = new Battle(player, wildpokemon);
            CreateNewBattle(battle);
        }

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
                    button.GetComponent<Image>().sprite = _attackTypeSprites.First(p => p.name == _battle.PlayerPokemon.GetMoves()[i].GetType().Name);
                    button.transform.Find("Move").gameObject
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
                    Debug.Log("no move bitch!");
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
            StartCoroutine(AttackTurn(moveNumber));
        }

        private IEnumerator AttackTurn(int playerMoveNumber)
        {
            //var first = _battle.WildPokemon == null ? _battle.FirstAttack(_battle.PlayerPokemon, _battle.WildPokemon) : _battle.FirstAttack(_battle.PlayerPokemon, _battle.OpponentPokemon);
            var first = _battle.FirstAttack(_battle.PlayerPokemon, _battle.WildPokemon ?? _battle.OpponentPokemon);
            var second = _battle.PlayerPokemon;
            var firstMove = _battle.PickRandomMove(_battle.WildPokemon) ??
                            _battle.PickRandomMove(_battle.OpponentPokemon);
            var secondMove = _battle.PlayerPokemon.GetMoves()[playerMoveNumber];

            if (first.Id == _battle.PlayerPokemon.Id)
            {
                second = _battle.WildPokemon ?? _battle.OpponentPokemon;
                secondMove = firstMove;
                firstMove = _battle.PlayerPokemon.GetMoves()[playerMoveNumber];
            }

            yield return UseAttack(first, second, firstMove);
            if (second.Fainted)
            {
                yield return EndBattle(second);
                if (second.Id == _battle.PlayerPokemon.Id)
                {
                    UpdateHpUi(_PlayerPanel, second);
                    UpdateHpUi(_EnemyPanel, first);
                }
                else
                {
                    UpdateHpUi(_EnemyPanel, first);
                    UpdateHpUi(_PlayerPanel, second);
                }
            }
            else
            {
                yield return UseAttack(second, first, secondMove);
                if (second.Id == _battle.PlayerPokemon.Id)
                {
                    UpdateHpUi(_PlayerPanel, second);
                    UpdateHpUi(_EnemyPanel, first);
                }
                else
                {
                    UpdateHpUi(_EnemyPanel, first);
                    UpdateHpUi(_PlayerPanel, second);
                }
            }
            if (first.Fainted)
            {
                yield return EndBattle(first);
            }
            yield return null;
        }

        public IEnumerator EndBattle(Pokemon pokemon)
        {
            if (pokemon.Id == _battle.PlayerPokemon.Id)
            {
                _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                    pokemon.Name + " has fainted.";
                yield return new WaitForSeconds(1f);
                _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                    "You lost the battle.";
            }
            else
            {
                _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                    pokemon.Name + " has fainted. You won the battle.";
                yield return new WaitForSeconds(1f);
                _textPanel.transform.Find("Text").gameObject.GetComponent<Text>().text =
                   "You won the battle.";
            }
            yield return new WaitForSeconds(1f);

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
            var text = _textPanel.transform.Find("Text").gameObject.GetComponent<Text>();
            bool flee;
            try
            {
                flee = _battle.Flee(_battle.PlayerPokemon);
                text.text = flee ? "You escaped the battle succesfully!" : "You could did not escape!";
            }
            catch (CannotFleeTrainerBattleException)
            {
                flee = false;
                text.text = "You cannot flee from a trainer battle!";
            }
            StartCoroutine("FleeAnimation", flee);
        }

        private IEnumerator WaitForSecondsAndInput()
        {
            var pressed = false;
            while (!pressed)
            {
                if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Space))
                {
                    pressed = true;
                }
                yield return null;
            }
        }
        private IEnumerator FleeAnimation(bool flee)
        {
            _mainPanel.SetActive(false);
            _textPanel.SetActive(true);
            _textPanel.transform.Find("ArrowPanel").gameObject.SetActive(false);
            yield return new WaitForSeconds(1f);
            _textPanel.transform.Find("ArrowPanel").gameObject.SetActive(true);
            
            if (flee)
            {
                yield return new WaitForSeconds(1f);
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

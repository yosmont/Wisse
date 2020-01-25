using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum BattleState { START, PLAYERTURN, PLAYERATTACK, ENEMYTURN, WIN, LOSE }

public class BattleSystem : MonoBehaviour
{
    public string _levelPath;

    public BattleState _state;
    public GameObject _player;
    public GameObject _enemy;
    private GameObject _playerGo;
    private GameObject _enemyGo;

    public Transform _playerBattleStation;
    public Transform _enemyBattleStation;

    public BattleHUD _playerHUD;
    public BattleHUD _enemyHUD;

    public Text _dialogueText;

    private GameObject _button;
    private bool _sword = true;
    private bool _mace = true;
    Unit _playerUnit;
    Unit _enemyUnit;

    void Start()
    {
        _state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        _button = GameObject.Find("Etranglement");
        _button.SetActive(false);
        _playerGo = Instantiate(_player, _playerBattleStation);
        _playerUnit = _playerGo.GetComponent<Unit>();

        _enemyGo = Instantiate(_enemy, _enemyBattleStation);
        _enemyUnit = _enemyGo.GetComponent<Unit>();

        _dialogueText.text = _enemyUnit.unitName + " apparait !";
        _playerHUD.SetHUD(_playerUnit);
        _enemyHUD.SetHUD(_enemyUnit);

        yield return new WaitForSeconds(1f);

        _state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(string type, int dmg)
    {
        bool isDead = _enemyUnit.TakeDamage(dmg);

        _playerGo.GetComponent<Animator>().Play("Hit");
        yield return new WaitForSeconds(1f);
        _enemyHUD.setHP(_enemyUnit.currentHp);
        _dialogueText.text = "Touché !";
        yield return new WaitForSeconds(2f);

        if (type == "sword")
        {
            _dialogueText.text = "Ton épée s'est brisée contre le corps du lion";
            
            yield return new WaitForSeconds(2f);
        }
        if (type == "mace")
        {
            _dialogueText.text = "Le bruit dérange " + _enemyUnit.unitName;
            yield return new WaitForSeconds(2f);
            _dialogueText.text = "La massue s'est brisée";
            yield return new WaitForSeconds(2f);
        }
        if (isDead)
        {
            _state = BattleState.WIN;
            endBattle();
        }
        else {
            _state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    void endBattle()
    {
        if (_state == BattleState.WIN)
        {
            _dialogueText.text = "Tu as gagné ! Mais tu perds un doigt.";
            StartCoroutine(LoadScene());
        }
        else
            _dialogueText.text = "Tu as perdu !";
    }

    IEnumerator LoadScene()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("src/scene/" + _levelPath);
    }

    IEnumerator EnemyTurn()
    {
        _dialogueText.text = _enemyUnit.unitName + " attaque !";
        _enemyGo.GetComponent<Animator>().Play("Hit");
        yield return new WaitForSeconds(1f);
        bool isDead = _playerUnit.TakeDamage(_enemyUnit.damage);
        _playerHUD.setHP(_playerUnit.currentHp);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            _state = BattleState.LOSE;
            endBattle();
        }
        else {
            _state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        if (_sword == false && _mace == false)
            _button.SetActive(true);
        _dialogueText.text = "À ton tour !";
    }

    public void OnMaceButton()
    {
        if (_mace)
        {
            if (_state != BattleState.PLAYERTURN)
                return;
            _state = BattleState.PLAYERATTACK;
            _mace = false;
            StartCoroutine(PlayerAttack("mace", 1));
        }
        else {
            if (_state == BattleState.PLAYERTURN)
                _dialogueText.text = "Ta massue est cassée";
        }
    }

    public void OnThrottlingButton()
    {
        if (_state != BattleState.PLAYERTURN)
            return;
        _state = BattleState.PLAYERATTACK;
        StartCoroutine(PlayerAttack("throttling", 100));
    }

    public void OnSwordButton()
    {
        if (_sword)
        {
            if (_state != BattleState.PLAYERTURN)
                return;
            _sword = false;
            _state = BattleState.PLAYERATTACK;
            StartCoroutine(PlayerAttack("sword", 1));
        }
        else {
            if (_state == BattleState.PLAYERTURN)
                _dialogueText.text = "Ton épée est cassée";
        }
    }

}

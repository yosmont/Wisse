using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURNE, ENEMYTURN, WIN, LOSE }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject player;
    public GameObject enemy;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    public Text DialogueText;

    Unit playerUnit;
    Unit enemyUnit;


    
    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
        GameObject playerGo = Instantiate(player, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        GameObject enemyGo = Instantiate(enemy, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        DialogueText.text = enemyUnit.unitName + " apparait !";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURNE;
        PlayerTurn();
    }

    IEnumerator PlayerAttack()
    {
        bool isDead = enemyUnit.TakeDamage(playerUnit.damage);

        enemyHUD.setHP(enemyUnit.currentHp);
        DialogueText.text = "Touché !";
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.WIN;
            endBattle();
        }
        else {
            state = BattleState.ENEMYTURN;
            StartCoroutine(EnemyTurn());
        }

    }
    void endBattle()
    {
        if (state == BattleState.WIN)
        {
            DialogueText.text = "Tu as gagné !";
        }
        else
            DialogueText.text = "Tu as perdu !";
    }

    IEnumerator EnemyTurn()
    {
        DialogueText.text = enemyUnit.unitName + "attaque !";
        yield return new WaitForSeconds(2f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.setHP(playerUnit.currentHp);
        if (isDead)
        {
            state = BattleState.LOSE;
            endBattle();
        }
        else {
            state = BattleState.PLAYERTURNE;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        DialogueText.text = "À ton tour !";
    }

    public void OnSwordButton()
    {
        if (state != BattleState.PLAYERTURNE)
            return;
        StartCoroutine(PlayerAttack());
    }


}

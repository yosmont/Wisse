using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, PLAYERATTACK, ENEMYTURN, WIN, LOSE }

public class BattleSystem : MonoBehaviour
{
    public BattleState state;
    public GameObject player;
    public GameObject enemy;
    private GameObject playerGo;
    private GameObject enemyGo;

    public Transform playerBattleStation;
    public Transform enemyBattleStation;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    public Text DialogueText;

    private GameObject Button;
    private bool sword = true;
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
        Button = GameObject.Find("Etranglement");
        Button.SetActive(false);
        playerGo = Instantiate(player, playerBattleStation);
        playerUnit = playerGo.GetComponent<Unit>();

        enemyGo = Instantiate(enemy, enemyBattleStation);
        enemyUnit = enemyGo.GetComponent<Unit>();

        DialogueText.text = enemyUnit.unitName + " apparait !";
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);

        yield return new WaitForSeconds(2f);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    IEnumerator PlayerAttack(string type, int dmg)
    {
        bool isDead = enemyUnit.TakeDamage(dmg);

        playerGo.GetComponent<Animator>().Play("Hit");
        yield return new WaitForSeconds(1f);
        enemyHUD.setHP(enemyUnit.currentHp);
        DialogueText.text = "Touché !";
        yield return new WaitForSeconds(2f);

        if (type == "sword")
        {
            DialogueText.text = "Ton épée s'est brisée contre le corps du lion";
            
            yield return new WaitForSeconds(2f);
        }
        if (type == "mace")
        {
            DialogueText.text = "Le bruit dérange " + enemyUnit.unitName;
            yield return new WaitForSeconds(2f);
        }
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
        DialogueText.text = enemyUnit.unitName + " attaque !";
        enemyGo.GetComponent<Animator>().Play("Hit");
        yield return new WaitForSeconds(1f);
        bool isDead = playerUnit.TakeDamage(enemyUnit.damage);
        playerHUD.setHP(playerUnit.currentHp);
        yield return new WaitForSeconds(2f);
        if (isDead)
        {
            state = BattleState.LOSE;
            endBattle();
        }
        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void PlayerTurn()
    {
        if (sword == false)
            Button.SetActive(true);
        DialogueText.text = "À ton tour !";
    }

    public void OnMaceButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.PLAYERATTACK;
        StartCoroutine(PlayerAttack("mace", 1));
    }

    public void OnThrottlingButton()
    {
        if (state != BattleState.PLAYERTURN)
            return;
        state = BattleState.PLAYERATTACK;
        StartCoroutine(PlayerAttack("throttling", 100));
    }

    public void OnSwordButton()
    {
        if (sword)
        {
            if (state != BattleState.PLAYERTURN)
                return;
            sword = false;
            state = BattleState.PLAYERATTACK;
            StartCoroutine(PlayerAttack("sword", 1));
        }
        else {
            if (state == BattleState.PLAYERTURN)
                DialogueText.text = "Ton épée est cassée";
        }
    }


}

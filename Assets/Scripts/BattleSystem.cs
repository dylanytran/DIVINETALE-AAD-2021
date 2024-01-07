using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState { START, PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleSystem : MonoBehaviour
{

    public BattleState state;

    public GameObject playerPrefab;
    //public GameObject enemyPrefab;
    public GameObject buttons;
    public GameObject bullet;
    public GameObject bullet2;
    public GameObject enemy;
    public GameObject sceneSwitcher;
    public GameObject gameOver;
    public float delayTime;
    public int wait;
    public int wave;
    public int wave2;
    
    public AudioClip attack;
    public AudioClip heal;
    public AudioClip generic;

    Stats playerStats;
    Stats enemyStats;

    public Text generalText;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    [Header ("Attack 1")]
    public float x1;
    public float x2;
    public float y1;
    public float y2;

    [Header ("Attack 2")]
    public float x3;
    public float x4;
    public float y3;
    public float y4;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle() {
        GameObject player = Instantiate(playerPrefab);
        playerStats = player.GetComponent<Stats>();
        buttons.SetActive(true);
        generalText.gameObject.SetActive(true);

        //public GameObject enemy = Instantiate(enemyPrefab);
        enemyStats = enemy.GetComponent<Stats>();

        generalText.text = "YOU ENCOUNTER: " + enemyStats.name;

        playerHUD.SetHUD(playerStats);
        enemyHUD.SetHUD(enemyStats);

        yield return new WaitForSeconds(delayTime);

        state = BattleState.ENEMYTURN;
        generalText.gameObject.SetActive(true);
        EnemyTurn();
    }

    void Update() {
        playerHUD.SetHP(playerStats.currentHP);
        enemyHUD.SetHP(enemyStats.currentHP);
        playerHUD.SetHUD(playerStats);
        enemyHUD.SetHUD(enemyStats);

    }

    IEnumerator PlayerAttack() {
        enemyStats.TakeDamage(playerStats.damage);
        SoundManager.instance.PlaySound(attack);
        
        generalText.text = "ATTACK WAS SUCCESSFUL!";

        yield return new WaitForSeconds(2f);

        if(enemyStats.isDead()) {
            state = BattleState.WON;
            EndBattle();
            yield return new WaitForSeconds(2f);
            sceneSwitcher.GetComponent<SceneSwitcher>().next(); //go next scence if enemy dies
        }

        else {
            state = BattleState.ENEMYTURN;
            EnemyTurn();
        } 
    }

    IEnumerator PlayerHeal() {
        playerStats.Heal(2);
        SoundManager.instance.PlaySound(heal);

        generalText.text = "YOUR HP HAS INCREASED!";

        yield return new WaitForSeconds(2f);

        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    IEnumerator PlayerPray() {
        int option = Random.Range(1, 6);
        SoundManager.instance.PlaySound(generic);

        if(option == 1) {
            generalText.text = "YOU PRAY TO GOD TO SURVIVE. ISN'T THAT IRONIC?";
        }

        if(option == 2) {
            generalText.text = "YOU HOPE YOU WON'T WAKE UP A GRAVE MAN.";
        }

        if(option == 3) {
            generalText.text = "NO ONE CAME TO ANSWER YOUR PRAYER.";
        }

        if(option == 4) {
            generalText.text = "YOU CALL FOR HELP.";
        }

        if(option == 5) {
            generalText.text = "YOUR PRAYER HAS BEEN ANSWERED! HP RESTORED TO FULL.";
            playerStats.Heal(playerStats.maxHP - playerStats.currentHP);
        }

        yield return new WaitForSeconds(3f);

        state = BattleState.ENEMYTURN;
        EnemyTurn();
    }

    void EnemyTurn() {
        generalText.text = "DODGE THE BULLETS";
        StartCoroutine(EnemyAttack());
    }

    IEnumerator EnemyAttack() {
        //spawn bullet at random location
        if(enemyStats.currentHP > (enemyStats.maxHP / 2)) {
            for(int i = 0; i < wave; i++) {
                Instantiate(bullet, new Vector3(Random.Range(x1, x2), Random.Range(y1, y2), 0), Quaternion.identity);
            }
        }
        else {
            for(int i = 0; i < wave2; i++) {
                Instantiate(bullet2, new Vector3(Random.Range(x3, x4), Random.Range(y3, y4), 0), Quaternion.identity);
            }
        }

        yield return new WaitForSeconds(wait);

        if(playerStats.isDead()) {
            state = BattleState.LOST;
            EndBattle();
            Destroy(playerPrefab);
            gameOver.SetActive(true);
        }

        else {
            state = BattleState.PLAYERTURN;
            PlayerTurn();
        }
    }

    void EndBattle() {
        if(state == BattleState.WON) {
            generalText.text = "YOU WON!";
        }

        else if(state == BattleState.LOST) {
            generalText.text = "YOU LOST!";
        }
    }

    void PlayerTurn() {
        generalText.text = "CHOOSE AN ACTION:";
        buttons.SetActive(true);
    }

    public void OnAttackButton() {
        if(state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerAttack());
        buttons.SetActive(false);
    }

    public void OnHealButton() {
        if(state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerHeal());
        buttons.SetActive(false);
    }

    public void OnPrayButton() {
        if(state != BattleState.PLAYERTURN)
            return;
        
        StartCoroutine(PlayerPray());
        buttons.SetActive(false);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneSwitcher : MonoBehaviour
{
    public GameObject sceneSwitcher;
    public GameObject deathSound;
    public GameObject npc;

    IEnumerator OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            deathSound.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            Destroy(npc);
            yield return new WaitForSeconds(2f);
            sceneSwitcher.GetComponent<SceneSwitcher>().next();
        }
    }
}

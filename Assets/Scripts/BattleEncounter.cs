using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BattleEncounter : MonoBehaviour
{
    public string sceneName;
    public GameObject sound;
    public GameObject exclamation;

    IEnumerator OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            sound.SetActive(true);
            exclamation.SetActive(true);
            yield return new WaitForSeconds(0.8f);
            SceneManager.LoadScene(sceneName);
        }
    }
}

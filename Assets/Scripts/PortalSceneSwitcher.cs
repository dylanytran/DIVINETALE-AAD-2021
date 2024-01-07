using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalSceneSwitcher : MonoBehaviour
{
    public string sceneName;
    //public GameObject sound;

    IEnumerator OnTriggerStay2D(Collider2D collision) {
        if(collision.gameObject.tag == "Player") {
            //sound.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(sceneName);
        }
    }
}


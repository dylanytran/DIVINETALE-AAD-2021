using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextSceneSwitcher : MonoBehaviour
{
    public string sceneName;
    public GameObject textTrigger;
    public Image black;
    public Animator anim;

    void Update() {
        if(textTrigger.activeInHierarchy) {
            StartCoroutine(Fading());
        }
    }

    IEnumerator Fading() {
        yield return new WaitForSeconds(3);
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(sceneName);
    }
}


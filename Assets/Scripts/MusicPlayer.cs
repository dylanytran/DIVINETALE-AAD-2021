using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public GameObject triggerText;
    public GameObject song;

    void Update()
    {
        playMusic();
    }

    void playMusic() {
        if(triggerText.activeInHierarchy) {
            song.SetActive(true);
        }
    }
}

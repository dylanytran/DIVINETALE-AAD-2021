using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DialogueSystem {

    public class IntroDialogueLine : IntroDialogueBaseClass {

        private Text textHolder;

        [Header ("Text Settings")]
        [SerializeField]private string input;

        [Header ("Time Settings")]
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;

        [Header ("Sound")]
        [SerializeField]private AudioClip sound;

        [Header ("Character Portrait")]
        [SerializeField]private Sprite characterSprite;
        [SerializeField]private Image imageHolder;
        
        private void Awake() {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            //imageHolder.sprite = characterSprite;
            //imageHolder.preserveAspect = true;
        }

        private void Start() {
            StartCoroutine(WriteText(input, textHolder, delay, sound, delayBetweenLines));
        }
    }
}
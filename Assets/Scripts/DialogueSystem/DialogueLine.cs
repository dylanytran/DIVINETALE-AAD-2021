using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DialogueSystem {

    public class DialogueLine : DialogueBaseClass {

        private Text textHolder;

        [Header ("Text Settings")]
        [SerializeField]private string input;

        [Header ("Time Settings")]
        [SerializeField]private float delay;
        [SerializeField]private float delayBetweenLines;

        [Header ("Sound")]
        [SerializeField]private AudioClip sound;

        /*[Header ("Character Portrait")]
        [SerializeField]private Sprite characterSprite;
        [SerializeField]private Image imageHolder;*/

        private IEnumerator lineAppear;
        
        /*private void Awake() {
            imageHolder.sprite = characterSprite;
            imageHolder.preserveAspect = true;
        }*/

        private void OnEnable() {
            ResetLine();
            lineAppear = (WriteText(input, textHolder, delay, sound, delayBetweenLines));
            StartCoroutine(lineAppear);
        }

        private void Update() {
            if(Input.GetMouseButtonDown(0)) {
                if(textHolder.text != input) {
                    StopCoroutine(lineAppear);
                    textHolder.text = input;
                }
                    
                else
                    finished = true;
            }
        }

        private void ResetLine() {
            textHolder = GetComponent<Text>();
            textHolder.text = "";
            finished = false;
        }
    }
}



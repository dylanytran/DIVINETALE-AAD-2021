using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace DialogueSystem {

    public class DialogueBaseClass : MonoBehaviour {

        public bool finished { get; protected set; }

        protected IEnumerator WriteText(string input, Text textHolder, float delay, AudioClip sound, float delayBetweenLines) {

            for(int i = 0; i < input.Length; i++) {

                textHolder.text += input[i];
                SoundManager.instance.PlaySound(sound);
                yield return new WaitForSeconds(delay);
            }

            //yield return new WaitForSeconds(delayBetweenLines);
            yield return new WaitUntil(()=> Input.GetMouseButton(0));

            finished = true;
        }
    }
}



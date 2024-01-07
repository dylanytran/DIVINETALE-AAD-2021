using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartMovement : MonoBehaviour
{
   public float speed;
   public Rigidbody2D body;
   private NPC_Controller npc;
   Vector2 movement; 
   //public GameObject sceneSwitcher;
   //public GameObject transitionText;

   private void Update() {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       transform.rotation = Quaternion.Euler(0, 0, 0);

       if(inDialogue()) {
            //movement = new Vector2(0, 0);
       }

       //if(transitionText.activeInHierarchy) {
           //sceneSwitcher.GetComponent<SceneSwitcher>().next();
       //}
   }

   void FixedUpdate() {
       body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime);
   }

   private bool inDialogue() {
        if(npc != null)
            return npc.DialogueActive();
        else 
            return false;
   }

   private void OnTriggerStay2D(Collider2D collision) {

       if(collision.gameObject.tag == "NPC") {
           npc = collision.gameObject.GetComponent<NPC_Controller>();
                npc.ActivateDialogue();
       }
   }

   private void OnTriggerExit2D(Collider2D collision) {
       npc = null;
   }
}

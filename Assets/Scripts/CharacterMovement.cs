using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
   public float speed;
   public Rigidbody2D body;
   private NPC_Controller npc;
   public Animator animator;
   Vector2 movement;
   public GameObject sceneSwitcher;
   public GameObject transitionText;
   public GameObject battleTrigger;

   private void Update() {
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");
       transform.rotation = Quaternion.Euler(0, 0, 0);

       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Speed", movement.sqrMagnitude);
       
       if(inDialogue()) {
           //disable all movement and animations in dialogue
            movement = new Vector2(0, 0);
            animator.SetFloat("Horizontal", 0);
            animator.SetFloat("Vertical", 0);
            animator.SetFloat("Speed", 0);
       }

       if(transitionText.activeInHierarchy) {
           battleTrigger.SetActive(true);
       }
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
           if(Input.GetKey(KeyCode.E))
                npc.ActivateDialogue();
       }
   }

   private void OnTriggerExit2D(Collider2D collision) {
       npc = null;
   }
}

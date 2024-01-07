using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpBullet : MonoBehaviour
{
    private Transform bullet;
    [SerializeField]public float speed;
    public GameObject enemy;
    public AudioClip hit;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet = GetComponent<Transform>();
    }

    void FixedUpdate() {
        //bullet.position += Vector3.up * -speed;
        bullet.position += Vector3.up * speed;
        if(bullet.position.y >= 10) {
            Destroy(bullet.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D playerCollider) {
        if(playerCollider.tag == "Player") {
            playerCollider.GetComponent<Stats>().TakeDamage(enemy.GetComponent<Stats>().damage);
            SoundManager.instance.PlaySound(hit);
            
            //player.gameObject.SetActive(false);
            //Destroy(player.gameObject);
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    // private PlayerMove movementScript;

    // // Start is called before the first frame update
    // void Start()
    // {
        
    // }

    // void OnTriggerEnter2D(Collider2D collision) {
    //     // Debug.Log("Some Collision detected");
    //     if (collision.gameObject.tag == "Player") {
    //         Debug.Log("Player Collision detected");
    //         //movementScript = collision.gameObject.GetComponent<PlayerMove>();
    //         //movementScript.runSpeed = 50f;
    //         collision.gameObject.GetComponent<PlayerMove>().increasedSpeed();
    //         StartCoroutine(speedDelay());
    //         movementScript.runSpeed = 10f;
    //     }
    // }

    // IEnumerator speedDelay() {
    //       yield return new WaitForSeconds(10f);
    //  }
    
    public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;

    void Start(){
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
    }

    public void OnTriggerEnter2D (Collider2D other){
        if (other.gameObject.tag == "Player"){
            GetComponent<Collider2D>().enabled = false;
            //GetComponent< AudioSource>().Play();
            StartCoroutine(DestroyThis());

            other.gameObject.GetComponent<PlayerMove>().increasedSpeed();
            //playerPowerupVFX.powerup();\
            DestroyThis();
        }
    }

    IEnumerator DestroyThis(){
          yield return new WaitForSeconds(0.3f);
          Destroy(gameObject);
    }
}

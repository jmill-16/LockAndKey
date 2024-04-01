using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedPowerup : MonoBehaviour
{
    private PlayerMove movementScript;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("Some Collision detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player Collision detected");
            //movementScript = collision.gameObject.GetComponent<PlayerMove>();
            //movementScript.runSpeed = 50f;
            collision.gameObject.GetComponent<PlayerMove>().increasedSpeed();
            StartCoroutine(speedDelay());
            movementScript.runSpeed = 10f;
        }
    }

    IEnumerator speedDelay() {
          yield return new WaitForSeconds(10f);
     }
}

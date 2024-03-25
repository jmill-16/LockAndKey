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

    void OnCollisionEnter2D(Collision2D collision) {
        // Debug.Log("Some Collision detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player Collision detected");
            movementScript = collision.gameObject.GetComponent<PlayerMove>();
            movementScript.startSpeed = 20;
            StartCoroutine(gravityDelay());
            movementScript.startSpeed = 10;
        }
    }

    IEnumerator gravityDelay() {
          yield return new WaitForSeconds(10f);
     }
}

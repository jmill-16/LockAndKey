using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("Some Collision detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player Collision detected");
            collision.attachedRigidbody.gravityScale = 2;
            StartCoroutine(gravityEffect(collision));
        }
    }

    IEnumerator gravityEffect(Collider2D collision) {
          yield return new WaitForSeconds(10f);
          collision.attachedRigidbody.gravityScale = 1;
     }
}

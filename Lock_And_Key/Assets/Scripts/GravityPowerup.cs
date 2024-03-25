using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision) {
        // Debug.Log("Some Collision detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player Collision detected");
            collision.rigidbody.gravityScale = 2;
            StartCoroutine(gravityEffect(collision));
        }
    }

    IEnumerator gravityEffect(Collision2D collision) {
          yield return new WaitForSeconds(10f);
          collision.rigidbody.gravityScale = 1;
     }
}

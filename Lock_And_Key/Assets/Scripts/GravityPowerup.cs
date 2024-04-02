using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    void OnTriggerEnter2D(Collider2D collision) {
        // Debug.Log("Some Collision detected");
        if (collision.gameObject.tag == "Player") {
            Debug.Log("Player Collision detected");
            Physics2D.gravity = new Vector2(0, 9.8f);
            playerSprite = collision.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
            playerSprite.flipY = true;
            StartCoroutine(gravityEffect(collision, playerSprite));
        }
    }

    IEnumerator gravityEffect(Collider2D collision, SpriteRenderer playerSprite) {
          yield return new WaitForSeconds(8f);
          playerSprite.flipY = false;
          Physics2D.gravity = new Vector2(0, -9.8f);
     }
}

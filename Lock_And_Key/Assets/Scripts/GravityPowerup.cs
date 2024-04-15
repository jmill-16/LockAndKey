using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private bool obtained;
    // Start is called before the first frame update
    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        obtained = false;
    }

    void Update() {
        if (obtained == true && Input.GetKeyDown("g")) {
            switchGravity();
        }
    }

    void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Gravity") {
            obtained = true;
        }
    }

    void switchGravity() {
        if (playerSprite.flipY == false) {
            Physics2D.gravity = new Vector2(0, 9.8f);
            playerSprite.flipY = true;
        } else {
            Physics2D.gravity = new Vector2(0, -9.8f);
            playerSprite.flipY = false;
        }
    }
}

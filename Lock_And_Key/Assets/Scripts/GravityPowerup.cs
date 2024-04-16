using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityPowerup : MonoBehaviour
{
    private SpriteRenderer playerSprite;
    private GameHandler gameHandler;
    private bool switched;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        playerSprite = this.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void Update() {
        switched = gameHandler.reverseGravityOn;
        switchGravity();
    }

    void switchGravity() {
        if (switched == true) {
            playerSprite.flipY = true;
            Physics2D.gravity = new Vector2(0, 9.8f);
        } else {
            playerSprite.flipY = false;
            Physics2D.gravity = new Vector2(0, -9.8f);
        }
    }
}

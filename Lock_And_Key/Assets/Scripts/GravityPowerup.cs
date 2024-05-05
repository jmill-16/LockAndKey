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

    public void switchGravity() {
        if (switched == true) {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = -1;
            playerSprite.flipY = true;
        } else {
            this.gameObject.GetComponent<Rigidbody2D>().gravityScale = 1;
            playerSprite.flipY = false;
        }
    }
}

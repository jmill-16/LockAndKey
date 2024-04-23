using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ConnorBetterFall : MonoBehaviour {

      private GameHandler gameHandler;
      public float fallMultiplier = 2.5f;
      public float lowJumpMultiplier = 2f;
      Rigidbody2D rb;

      void Awake(){
            rb = GetComponent <Rigidbody2D> ();
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

      void Update() {
        if (!gameHandler.reverseGravityOn) {
            if (rb.velocity.y < 0) {
                  rb.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (rb.velocity.y > 0 && !Input.GetButton ("Jump")){
                  rb.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        } else if (gameHandler.reverseGravityOn) {
            if (rb.velocity.y > 0) {
                  rb.velocity += Vector2.down * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            } else if (rb.velocity.y < 0 && !Input.GetButton ("Jump")){
                  rb.velocity += Vector2.down * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
      }
}
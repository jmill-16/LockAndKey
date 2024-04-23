using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class ConnorPlayerJump : MonoBehaviour {

      //public Animator anim;
      private GameHandler gameHandler;
      public Rigidbody2D rb;
      public float jumpForce = 0.005f;
      public Transform feet;
      public LayerMask groundLayer;
      public LayerMask enemyLayer;
      public bool canJump = false;
      public int jumpTimes = 0;
      public bool isAlive = true;
      //public AudioSource JumpSFX;

      void Start(){
            //anim = gameObject.GetComponentInChildren<Animator>();
            rb = this.gameObject.GetComponent<Rigidbody2D>();
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
      }

     void Update() {
            if ((IsGrounded()) && (jumpTimes <= 1)){
            // if ((IsGrounded()) && (jumpTimes <= 1)){ // for single jump only
                  canJump = true;
            }  else {
            // else { // for single jump only
                  canJump = false;
            }

            if (!gameHandler.reverseGravityOn && (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && (canJump) && (isAlive == true)) {
                  Jump();
            } else if (gameHandler.reverseGravityOn && (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && (canJump) && (isAlive == true)) {
                  switchJump();
            }
      }

      public void Jump() {
            jumpTimes += 1;
            rb.velocity = Vector2.up * jumpForce;
            // anim.SetTrigger("Jump");
            // JumpSFX.Play();

            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      }

      public void switchJump() {
            jumpTimes += 1;
            rb.velocity = Vector2.down * jumpForce;
            // anim.SetTrigger("Jump");
            // JumpSFX.Play();

            //Vector2 movement = new Vector2(rb.velocity.x, jumpForce);
            //rb.velocity = movement;
      }

      public bool IsGrounded() {
            Collider2D groundCheck = Physics2D.OverlapCircle(feet.position, 0.5f, groundLayer);
            Collider2D enemyCheck = Physics2D.OverlapCircle(feet.position, 0.5f, enemyLayer);
            if ((groundCheck != null) || (enemyCheck != null)) {
                  //Debug.Log("I am trouching ground!");
                  jumpTimes = 0;
                  return true;
            }
            return false;
      }
}

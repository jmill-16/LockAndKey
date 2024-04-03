using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMove : MonoBehaviour {

      //public Animator animator;
      public Rigidbody2D rb2D;
      private bool FaceRight = true; // determine which way player is facing.
      public float runSpeed = 5f;
      public float startSpeed = 5f;
      public bool isAlive = true;

      AudioSource audioSourse;
      //public AudioSource WalkSFX;
      private Vector3 hMove;

      void Start(){
           //animator = gameObject.GetComponentInChildren<Animator>();
           rb2D = transform.GetComponent<Rigidbody2D>();
           audioSourse = GetComponent<AudioSource>();
      }

    //   void Update(){
    //         //NOTE: Horizontal axis: [a] / left arrow is -1, [d] / right arrow is 1
    //        hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
    //        if (isAlive == true){
    //               transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

    //               if (Input.GetAxis("Horizontal") != 0){
    //                     if(!audioSourse.isPlaying)
    //                     {
    //                           audioSourse.Play();
    //                     }
    //               //       animator.SetBool ("Walk", true);
    //               //       if (!WalkSFX.isPlaying){
    //               //             WalkSFX.Play();
    //               //      }
    //               } else {
    //                     audioSourse.Stop();
    //               //      animator.SetBool ("Walk", false);
    //               //      WalkSFX.Stop();
    //               }

    //               // Turning: Reverse if input is moving the Player right and Player faces left
    //              if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
    //                     playerTurn();
    //               }
    //        }

    //   //      if(rb2D.velocity.x != 0)
    //   //      {
    //   //             if(!audioSourse.isPlaying)
    //   //             {
    //   //                   audioSourse.Play();
    //   //             }
    //   //      }
    //   //      else
    //   //      {
    //   //             audioSourse.Stop();
    //   //      }
    //   }

      void FixedUpdate(){
            //slow down on hills / stops sliding from velocity
            if (hMove.x == 0){
                  rb2D.velocity = new Vector2(rb2D.velocity.x / 1.1f, rb2D.velocity.y) ;
            }

            hMove = new Vector3(Input.GetAxis("Horizontal"), 0.0f, 0.0f);
            if (isAlive == true){
                  transform.position = transform.position + hMove * runSpeed * Time.deltaTime;

                  if (Input.GetAxis("Horizontal") != 0){
                        if(!audioSourse.isPlaying)
                        {
                              audioSourse.Play();
                        }
                  //       animator.SetBool ("Walk", true);
                  //       if (!WalkSFX.isPlaying){
                  //             WalkSFX.Play();
                  //      }
                  } else {
                        audioSourse.Stop();
                  //      animator.SetBool ("Walk", false);
                  //      WalkSFX.Stop();
                  }

                  // Turning: Reverse if input is moving the Player right and Player faces left
                 if ((hMove.x <0 && !FaceRight) || (hMove.x >0 && FaceRight)){
                        playerTurn();
                  }
            }
      }

      private void playerTurn(){
            // NOTE: Switch player facing label
            FaceRight = !FaceRight;

            // NOTE: Multiply player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
      }

      public void increasedSpeed() {
            runSpeed = 10f;
      }
}

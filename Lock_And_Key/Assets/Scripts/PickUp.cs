using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      AudioSource audioSourseON;
      AudioSource audioSourseOFF;
      //public playerVFX playerPowerupVFX;
      

      //ADD OTHER POWER PICKUPS HERE
      public bool isSpeedBoostPickUp = false;

      //Indicates if viewhidden needs to be turned on to find this
      public bool hiddenObject = true;

      public bool currentVisible = false;

      public bool keyToDoor;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            audioSourseON = GetComponent<AudioSource>();
            audioSourseOFF = GetComponent<AudioSource>();

            //gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }


      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  if (hiddenObject) {
                        if (gameHandler.viewHiddenOn) {
                              //Debug.Log("view hidden on");
                              if(!audioSourseOFF.isPlaying)
                              {
                                    audioSourseOFF.Play();
                              }

                              GetComponent<Collider2D>().enabled = false;
                              //Debug.Log("here1");
                              if (keyToDoor) {
                                    //Debug.Log("can open true");
                                    gameHandler.canOpenDoor = true;
                              }
                              //Debug.Log("here2");
                              //GetComponent< AudioSource>().Play();
                              StartCoroutine(DestroyThis());
                        } 
                        if(!gameHandler.viewHiddenOn) {
                              //Debug.Log("view hidden off");
                              // if(!audioSourseOFF.isPlaying)
                              // {
                              //       audioSourseOFF.Play();
                              // }     
                        }
                  } else {
                        if(!audioSourseOFF.isPlaying)
                        {
                              audioSourseOFF.Play();
                        }

                        GetComponent<Collider2D>().enabled = false;
                        //Debug.Log("here1");
                        if (keyToDoor) {
                              //Debug.Log("can open true");
                              gameHandler.canOpenDoor = true;
                        }
                        //Debug.Log("here2");
                        //GetComponent< AudioSource>().Play();
                        StartCoroutine(DestroyThis());

                  }
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}
using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PickUp : MonoBehaviour{

      public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
      

      //ADD OTHER POWER PICKUPS HERE
      public bool isSpeedBoostPickUp = false;

      //Indicates if viewhidden needs to be turned on to find this
      public bool hiddenObject = true;

      public bool currentVisible = false;

      public bool keyToDoor;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }


      public void OnTriggerEnter2D (Collider2D other){
            if (other.gameObject.tag == "Player"){
                  if (hiddenObject) {
                        if (gameHandler.viewHiddenOn) {
                              GetComponent<Collider2D>().enabled = false;
                              if (keyToDoor) {
                                    Debug.Log("can open true");
                                    gameHandler.canOpenDoor = true;
                              }
                              //GetComponent< AudioSource>().Play();
                              StartCoroutine(DestroyThis());
                        }
                  }
            }
      }

      IEnumerator DestroyThis(){
            yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
      }

}
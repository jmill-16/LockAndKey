using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorExit_Items : MonoBehaviour{
      // NOTE: This script depends on the GameHandler having a public int "thePieces"
      // that is updated with each pickup collected.
      public GameHandler gameHandler;
      public string NextLevel;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            gameObject.GetComponent<Collider2D>().enabled = false;
      }

      void Update(){
            if (gameHandler.canOpenDoor){
                Debug.Log("door available");
                  gameObject.GetComponent<Collider2D>().enabled = true;
            }
            else {
                  gameObject.GetComponent<Collider2D>().enabled = false;
            }
      }

      public void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  SceneManager.LoadScene (NextLevel);
            }
      }
}
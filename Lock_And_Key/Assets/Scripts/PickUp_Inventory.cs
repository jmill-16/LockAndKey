using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp_Inventory: MonoBehaviour {

      private GameInventory gameInventory;
      public string ItemName = "item1";

      void Awake(){
            if (GameObject.FindWithTag("GameHandler") != null) {
                  gameInventory = GameObject.FindWithTag("GameHandler").GetComponent<GameInventory>();
            }
      }

      void OnTriggerEnter2D(Collider2D other){
            if (other.gameObject.tag == "Player"){
                  Debug.Log("You found an" + ItemName);
                  
            if (gameInventory != null) {
                gameInventory.InventoryAdd(ItemName);
            } else {
                Debug.LogWarning("GameInventory is not assigned.");
            }
            }
      }
}

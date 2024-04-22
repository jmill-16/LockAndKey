using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameInventory : MonoBehaviour {
      public GameObject InventoryMenu;
      //public GameObject CraftMenu;
      public bool InvIsOpen = false;

      //5 Inventory Items:
      public bool hiddenpoweravail = true;
      public bool secondpoweravail;
    //   public static bool item2bool = false;
    //   public static bool item3bool = false;
    //   public static bool item4bool = false;
    //   public static bool item5bool = false;

    //   public static int item1num = 0;
    //   public static int item2num = 0;
    //   public static int item3num = 0;
    //   public static int item4num = 0;
    //   public static int item5num = 0;
      //public static int coins = 0;

      [Header("Add item image objects here")]
      public GameObject item1image; //HiddenPower game object
      public GameObject item2image; //second power game object
    //   public GameObject item3image;
    //   public GameObject item4image;
    //   public GameObject item5image;
      //public GameObject coinText;

      // Item number text variables. Comment out if each item is unique (1/2).
      [Header("Add item number Text objects here")]
      public Text item1Text;  //Hidden power text
      public Text item2Text; //second power text
    //   public Text item3Text;
    //   public Text item4Text;
    //   public Text item5Text;

      // Crafting buttons. Uncomment and add for each button:
      // public GameObject buttonCraft1; // weapon1 creation


      //Selected boxes
      public GameObject item1selected;
      public GameObject item2selected;

      public GameHandler gameHandler;
 
      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            InventoryMenu.SetActive(false);
            //CraftMenu.SetActive(false);
            InventoryDisplay();
      }

      void Update(){
        if (Input.GetKeyDown("i")) {
            //Debug.Log("i pressed");
            OpenCloseInventory();
            //InventoryDisplay();
        }
        if (Input.GetKeyDown("u") && secondpoweravail) {
            if (gameHandler.selectedHiddenPower) {
                  gameHandler.viewHiddenOn = false;
                  gameHandler.selectedHiddenPower = false;

                  if (gameHandler.levelPower == "speed") {
                        gameHandler.speedOn = true;
                  } else if (gameHandler.levelPower == "reversegravity") {
                        gameHandler.reverseGravityOn = true;
                  } else if (gameHandler.levelPower == "colorview") {
                        gameHandler.viewPurpleOn = true;
                  }
            } else {
                  gameHandler.viewHiddenOn = true;
                  gameHandler.selectedHiddenPower = true;

                  if (gameHandler.levelPower == "speed") {
                        gameHandler.speedOn = false;
                  } else if (gameHandler.levelPower == "reversegravity") {
                        gameHandler.reverseGravityOn = false;
                  } else if (gameHandler.levelPower == "colorview") {
                        gameHandler.viewPurpleOn = false;
                  }
            }
        }

        if (InvIsOpen) {
            InventoryDisplay();
        }
      }

      void InventoryDisplay(){
            if (hiddenpoweravail == true) {item1image.SetActive(true);} else {item1image.SetActive(false);}
            if (secondpoweravail == true) {item2image.SetActive(true);} else {item2image.SetActive(false);}
            
            if (gameHandler.selectedHiddenPower) {
                  //Debug.Log("here1");
                  item1selected.SetActive(true);
                  item2selected.SetActive(false);
            }
            else {
                  //Debug.Log("here2");
                  item1selected.SetActive(false);
                  if (secondpoweravail) {
                        item2selected.SetActive(true);
                  }
            }

            // if (item3bool == true) {item3image.SetActive(true);} else {item3image.SetActive(false);}
            // if (item4bool == true) {item4image.SetActive(true);} else {item4image.SetActive(false);}
            // if (item5bool == true) {item5image.SetActive(true);} else {item5image.SetActive(false);}

            //Text coinTextB = coinText.GetComponent<Text>();
            //coinTextB.text = ("COINS: " + coins);

            // Item number updates. Comment out if each item is unique (2/2).
            // Text item1TextB = item1Text.GetComponent<Text>();
            // item1TextB.text = ("" + item1num);

            // Text item2TextB = item2Text.GetComponent<Text>();
            // item2TextB.text = ("" + item2num);

            // Text item3TextB = item3Text.GetComponent<Text>();
            // item3TextB.text = ("" + item3num);

            // Text item4TextB = item4Text.GetComponent<Text>();
            // item4TextB.text = ("" + item4num);

            // Text item5TextB = item5Text.GetComponent<Text>();
            // item5TextB.text = ("" + item5num);
      }

      public void InventoryAdd(string item){
            string foundItemName = item;
            if (foundItemName == "item1") {hiddenpoweravail = true;}
            else if (foundItemName == "item2") {secondpoweravail = true;}
            // else if (foundItemName == "item3") {item3bool = true; item3num ++;}
            // else if (foundItemName == "item4") {item4bool = true; item4num ++;}
            // else if (foundItemName == "item5") {item5bool = true; item5num ++;}
            else { Debug.Log("This item does not exist to be added"); }
            InventoryDisplay();

            if (!InvIsOpen){
                  OpenCloseInventory();
            }
      }

      public void InventoryRemove(string item){
            string itemRemove = item;
            if (itemRemove == "item1") {
                hiddenpoweravail = false;
                //   item1num -= num;
                //   if (item1num <= 0) { item1bool =false; }
                  // Add any other intended effects: new item crafted, speed boost, slow time, etc
             }
            else if (itemRemove == "item2") {
                  secondpoweravail =false;
                  // Add any other intended effects
             }
            // else if (itemRemove == "item3") {
            //       item3num -= num;
            //       if (item3num <= 0) { item3bool =false; }
            //         // Add any other intended effects
            // }
            // else if (itemRemove == "item4") {
            //       item4num -= num;
            //       if (item4num <= 0) { item4bool =false; }
            //         // Add any other intended effects
            // }
            // else if (itemRemove == "item5") {
            //       item5num -= num;
            //       if (item5num <= 0) { item5bool =false; }
            //         // Add any other intended effects
            // }
            else { Debug.Log("This item does not exist to be removed"); }
            InventoryDisplay();
      }

      //public void CoinChange(int amount){
            //coins +=amount;
            //InventoryDisplay();
      //}

      // Open and Close the Inventory. Use this function on a button next to the inventory bar.
      public void OpenCloseInventory(){
            if (InvIsOpen){ InventoryMenu.SetActive(false);}
            else { InventoryMenu.SetActive(true); }
            InvIsOpen = !InvIsOpen;
      }

      //Open and Close the Cookbook
      //public void OpenCraftBook(){CraftMenu.SetActive(true);}
      //public void CloseCraftBook(){CraftMenu.SetActive(false);}

      // Reset all static inventory values on game restart.
      public void ResetAllInventory(){
            hiddenpoweravail = true;
            secondpoweravail = false;
            // item3bool = false;
            // item4bool = false;
            // item5bool = false;

            // item1num = 0; // object name
            // item2num = 0; // object name
            // item3num = 0; // object name
            // item4num = 0; // object name
            // item5num = 0; // object name
      }

}

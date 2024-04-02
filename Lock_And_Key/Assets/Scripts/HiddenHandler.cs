using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameHandler gameHandler;
      //public playerVFX playerPowerupVFX;
    
    public GameObject hiddenObj;

    public bool notDestroyed = true;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            hiddenObj = GameObject.FindWithTag("Hidden");
            if (hiddenObj.GetComponent<PickUp>().hiddenObject) {
                hiddenObj.SetActive(false);
            }
            //gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            //playerPowerupVFX = GameObject.FindWithTag("Player").GetComponent<playerVFX>();
      }

      public void Update() {
        //hiddenObj.SetActive(true);
        if (hiddenObj) {
            if (gameHandler.viewHiddenOn) {
                //Debug.Log("turning on");
                hiddenObj.SetActive(true);
                //Debug.Log("turned on");
            } else {
                //Debug.Log("turning off");
                hiddenObj.SetActive(false);
            }
        }
      }
}

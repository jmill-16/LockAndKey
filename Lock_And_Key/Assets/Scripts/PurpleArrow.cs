using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurpleArrow : MonoBehaviour
{

    public GameHandler gameHandler;

    GameObject[] allPurpleArrows;
    GameObject[] allBlueArrows;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        allBlueArrows = GameObject.FindGameObjectsWithTag("BlueArrow"); 
        allPurpleArrows = GameObject.FindGameObjectsWithTag("PurpleArrow"); 
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameHandler.selectedHiddenPower) {
            Debug.Log("color");
            if (gameHandler.viewPurpleOn) {
                //Debug.Log("pruple");
                foreach (GameObject purplearrow in allPurpleArrows) 
                    purplearrow.SetActive(true); 
                foreach (GameObject bluearrow in allBlueArrows) 
                    bluearrow.SetActive(false); 
            } else {
                //Debug.Log("blue");
                foreach (GameObject purplearrow in allPurpleArrows) 
                    purplearrow.SetActive(false); 
                foreach (GameObject bluearrow in allBlueArrows) 
                    bluearrow.SetActive(true); 
            }
        } else {
            //Debug.Log("disappear");
            foreach (GameObject purplearrow in allPurpleArrows) 
                purplearrow.SetActive(false); 
            foreach (GameObject bluearrow in allBlueArrows) 
                bluearrow.SetActive(false); 
        }
        
    }
}

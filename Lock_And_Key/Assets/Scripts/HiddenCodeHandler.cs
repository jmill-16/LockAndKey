using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenCodeHandler : MonoBehaviour
{
    // Start is called before the first frame update

    public GameHandler gameHandler;
    
    public GameObject hiddenObj;
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        hiddenObj = GameObject.FindWithTag("Hidden");
        hiddenObj.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
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

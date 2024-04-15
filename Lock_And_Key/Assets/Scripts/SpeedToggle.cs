using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedToggle : MonoBehaviour
{

    public GameHandler gameHandler;
    public float runSpeed = 0f;
    public bool superSpeed = false;

    // Start is called before the first frame update
    void Start()
    {
        
        runSpeed = GetComponent<PlayerMove>().runSpeed;
        Debug.Log("run speed = " + runSpeed); 
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("p")) {
        //     superSpeed = !superSpeed;
        // }
        superSpeed = gameHandler.speedOn;

        if (superSpeed == false) {
            GetComponent<PlayerMove>().runSpeed = runSpeed;
        }

        if(superSpeed == true) {
            // Debug.Log("super speed on");
            GetComponent<PlayerMove>().runSpeed = 1.5f * runSpeed;
        }

    }
}

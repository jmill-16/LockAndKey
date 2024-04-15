using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedToggle : MonoBehaviour
{

    public GameHandler gameHandler;

    public Camera cam;
    public float camSize = 5f;

    public float changingSize = 0f;

    public float speedCamSize = 7.5f;
    public float fadeSize = 5f;
    public float runSpeed = 0f;
    public bool superSpeed = false;

    public float fadeSpeed = 1.1f;



    // Start is called before the first frame update
    void Start()
    {
        camSize = cam.orthographicSize;
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
            cam.orthographicSize = camSize;
        }

        if(superSpeed == true) {
            
            GetComponent<PlayerMove>().runSpeed = 1.5f * runSpeed;
            // StartCoroutine(FadeOut());
            cam.orthographicSize = speedCamSize;
        }

    }

    // IEnumerator FadeOut() {
    //     while(cam.orthographicSize < speedCamSize) {
    //         changingSize = cam.orthographicSize;
    //         fadeSize = changingSize + (fadeSpeed * Time.deltaTime);
    //         Debug.Log("changingSize: " + changingSize);
    //         Debug.Log("fadeSize: " + fadeSize);
    //         Debug.Log("speedCamSize: " + speedCamSize);
            

    //         cam.orthographicSize = fadeSize;
    //         yield return null;
    //     }
    // }
}



using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDoorKey : MonoBehaviour
{
    // Start is called before the first frame update

    public GameHandler gameHandler;
    public GameObject canvaskeyicon;
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        canvaskeyicon.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameHandler.canOpenDoor)
        {
            canvaskeyicon.SetActive(true);
        }
        
    }
}

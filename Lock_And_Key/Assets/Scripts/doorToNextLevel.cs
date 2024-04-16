using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorToNextLevel : MonoBehaviour
{
    public GameHandler gameHandler;
    public string nextRoom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Player"){
            Debug.Log("collision working");
            if (nextRoom == "L3T") {
                gameHandler.ToLevel3();
            }
            if(nextRoom == "L1D2") {
                gameHandler.ToDungeon2();
            }
            if(nextRoom == "L2D1") {
                gameHandler.ToLevel2Start();
            }
            if(nextRoom == "THP") {
                gameHandler.ToTutHiddenPower();
            }
            if(nextRoom == "L1D1"){
                gameHandler.StartLevel1();
            }
        }
    }
}

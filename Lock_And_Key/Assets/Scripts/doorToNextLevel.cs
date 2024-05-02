using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorToNextLevel : MonoBehaviour
{
    public GameHandler gameHandler;
    public string nextRoom;

    // AudioManager audioManager;

    // private void Awake()
    // {
    //     Debug.Log("when are you called");
    //     audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    // }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {   
        if(other.gameObject.tag == "Player"){
            // audioManager.PlaySFX(audioManager.unlockDoor);
            if (nextRoom == "L3T") {
                gameHandler.ToLevel3();
            }
            if(nextRoom == "L1D2") {
                gameHandler.ToDungeon2();
            }
            if(nextRoom == "L2D1") {
                gameHandler.ToLevel2Start();
            }
            if(nextRoom == "L2D2") {
                gameHandler.ToLevel2Dungeon();
            }
            if(nextRoom == "THP") {
                gameHandler.ToTutHiddenPower();
            }
            if(nextRoom == "L1D1"){
                gameHandler.StartLevel1();
            }
            if(nextRoom == "L1D3"){
                gameHandler.ToDungeon3();
            }
            if(nextRoom == "DB"){
                gameHandler.ToDungeonBoss();
            }
        }
    }
}

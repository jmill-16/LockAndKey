using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;

public class countdown : MonoBehaviour
{
    public GameObject timerWall;
    public GameObject timer;
    public GameObject player;
    public GameObject spawnPoint;
    public Vector3 spawn;
    public bool isRunning = false;
    GameObject[] fadingPlats;
    Color startColor;
    Color fullAlpha;


    public float startTime = 60f;
    public float timeLeft = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        timerWall = GameObject.FindWithTag("TimerWall");
        Debug.Log("x: " + spawn.x + "y: " + spawn.y + "z: " +  spawn.z);
        fadingPlats = GameObject.FindGameObjectsWithTag("FadingPlatform");
        startColor = fadingPlats[0].transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
        fullAlpha = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRunning == true) {
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Round(timeLeft * 100.0f) * 0.01f;
            Text timerText = timer.GetComponent<Text>();
            timerText.text = "Time remaining: " + timeLeft;
            if(timeLeft <= 0f){
                timerText.text = "Time remaining: 0";
                player.transform.position = spawn;
                timerWall.SetActive(true);
                isRunning = false;
            }
        }

        // if(timerWall.GetComponent<TilemapCollider2D>().enabled == true) {
        //     Debug.Log("collider is still on");
        // }
    }

    public void StartTimer() {
        if(isRunning == false){
            timerWall.SetActive(false);
            timeLeft = startTime;
            isRunning = true;
        }
    }

    public void RestartLevel() {
        if(isRunning == true) {
            timerWall.SetActive(true);
            timeLeft = startTime;
            player.transform.position = spawn;
            foreach (GameObject plat in fadingPlats) {
                plat.SetActive(true);
                plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
            }
            isRunning = false;
        }
    }
}

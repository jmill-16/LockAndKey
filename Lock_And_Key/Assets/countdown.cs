using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class countdown : MonoBehaviour
{
    public GameObject timerWall;
    public GameObject timer;
    public GameObject player;
    public GameObject spawnPoint;
    private Vector3 spawn = new Vector3(0,0,0);
    public bool isRunning = false;
    public float timeLeft = 60f;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
        timerWall = GameObject.FindWithTag("TimerWall");
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(isRunning == true) {
            timeLeft -= Time.deltaTime;
            timeLeft = Mathf.Round(timeLeft * 100.0f) * 0.01f;
            Text timerText = timer.GetComponent<Text>();
            timerText.text = "Time remaining: " + timeLeft;
            Debug.Log(timeLeft);
            if(timeLeft <= 0f){
                timerText.text = "Time remaining: 0";
                player.transform.position = spawn;
                timerWall.SetActive(true);
                isRunning = false;
            }
        }
    }

    public void StartTimer() {
        if(isRunning == false){
            timerWall.SetActive(false);
            timeLeft = 10f;
            isRunning = true;
        }
    }
}

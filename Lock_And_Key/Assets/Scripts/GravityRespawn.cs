using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityRespawn : MonoBehaviour
{
    private GameHandler gameHandler;
    public float threshold;
    public float gThreshold;
    public Vector3 spawn;

    GameObject[] fadingPlats;

    Color startColor;

    Color fullAlpha;

    public GameObject player;

    // public bool activatedCheckpoint = false;

    // public GameObject gameHandler;

    // Countdown cd;

    // Start is called before the first frame update
    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        fadingPlats = GameObject.FindGameObjectsWithTag("FadingPlatform");
        if(fadingPlats.Length > 0) {
            startColor = fadingPlats[0].transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
            fullAlpha = new Color(startColor.r, startColor.g, startColor.b, 1f);
        }
        // gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        // cd = gameHandler.GetComponent<Countdown>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold || transform.position.y > gThreshold) {
            transform.position = spawn;
            gameHandler.reverseGravityOn = false;
            foreach (GameObject plat in fadingPlats) {
                plat.SetActive(true);
                plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
            }
        }

        // if (cd.restarted == true) {
        //     activatedCheckpoint = false;
        //     spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        // }
    }

    // public void OnTriggerEnter2D(Collider2D other) {
    //     if(other.gameObject.tag == "Checkpoint") {
    //         spawn = other.transform.position;
    //         Debug.Log("checkpoint works");
    //         activatedCheckpoint = true;
    //     }
    // }

    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Spikes"){
            Debug.Log("working");
            player.transform.position = spawn;
            foreach (GameObject plat in fadingPlats) {
                plat.SetActive(true);
                plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
            }
        }
    }
}
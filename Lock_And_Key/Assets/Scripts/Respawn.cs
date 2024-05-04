using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    public Vector3 spawn = new Vector3(0,0,0);

    // public PlayerHealth playerHealth;

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
        player = GameObject.FindGameObjectWithTag("Player");
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        fadingPlats = GameObject.FindGameObjectsWithTag("FadingPlatform");
        Debug.Log("num of fading plats = " + fadingPlats.Length);
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
        if (transform.position.y < threshold) {
            transform.position = spawn;
            player.GetComponent<PlayerHealth>().health = player.GetComponent<PlayerHealth>().maxHealth;
            if(fadingPlats.Length > 0) {
                foreach (GameObject plat in fadingPlats) {
                    plat.SetActive(true);
                    plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
                }
            }
        }

        // if(playerHealth.health <= 0) {
        //     Debug.Log("hey");
        // }


        if (GetComponent<PlayerHealth>().health <=0) {
            transform.position = spawn;
            if(fadingPlats.Length > 0) {
                foreach (GameObject plat in fadingPlats) {
                    plat.SetActive(true);
                    plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
                }
            }
            GetComponent<PlayerHealth>().health = GetComponent<PlayerHealth>().maxHealth;
        }

        if (cd.restarted == true) {
            activatedCheckpoint = false;
            spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        }
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
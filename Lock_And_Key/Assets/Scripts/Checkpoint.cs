using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{   
    public GameObject player;
    public GameObject gameHandler;
    Countdown cd;
    Respawn rsp;
    public bool isActivated = false;
    SpriteRenderer sp;
    public Sprite unactivated;
    public Sprite activated;
    public bool reset;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        gameHandler = GameObject.FindGameObjectWithTag("GameHandler");
        rsp = player.GetComponent<Respawn>();
        sp = GetComponent<SpriteRenderer>();
        cd = gameHandler.GetComponent<Countdown>();
    }

    // Update is called once per frame
    void Update()
    {   if (cd != null)
            reset = cd.restarted;
            if (reset == true) {
                resetCheckpoint();
            }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Player"){
            rsp.spawn = this.transform.position;
            sp.sprite = activated;
        }

    }

    void resetCheckpoint() {
        sp.sprite = unactivated;
        rsp.spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
    }
}

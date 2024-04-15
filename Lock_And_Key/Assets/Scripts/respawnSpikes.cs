using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpikes : MonoBehaviour
{
    private Vector3 spawn = new Vector3(0,0,0);
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        Debug.Log(spawn);
    }

    
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("working");
            player.transform.position = spawn;
        }
    }
}
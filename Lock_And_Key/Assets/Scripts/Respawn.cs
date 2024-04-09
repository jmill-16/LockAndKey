using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    private Vector3 spawn = new Vector3(0,0,0);

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold) {
            transform.position = spawn;
        }
    }
}
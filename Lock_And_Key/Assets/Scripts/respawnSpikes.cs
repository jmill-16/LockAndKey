using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnSpikes : MonoBehaviour
{
    private Vector3 spawn = new Vector3(0,0,0);
    public GameObject player;

    GameObject[] fadingPlats;

    Color startColor;

    Color fullAlpha;
    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        Debug.Log(spawn);
        fadingPlats = GameObject.FindGameObjectsWithTag("FadingPlatform");
        Debug.Log("num of fading plats = " + fadingPlats.Length);
        startColor = fadingPlats[0].transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
        fullAlpha = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }

    
    public void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == "Player"){
            Debug.Log("working");
            player.transform.position = spawn;
            foreach (GameObject plat in fadingPlats) {
                plat.SetActive(true);
                plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
            }
        }
    }
}
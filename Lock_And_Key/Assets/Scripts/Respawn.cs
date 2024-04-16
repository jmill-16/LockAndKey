using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public float threshold;
    private Vector3 spawn = new Vector3(0,0,0);

    GameObject[] fadingPlats;

    Color startColor;

    Color fullAlpha;

    // Start is called before the first frame update
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        threshold = -10;
        fadingPlats = GameObject.FindGameObjectsWithTag("FadingPlatform");
        Debug.Log("num of fading plats = " + fadingPlats.Length);
        startColor = fadingPlats[0].transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
        fullAlpha = new Color(startColor.r, startColor.g, startColor.b, 1f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < threshold) {
            transform.position = spawn;
            foreach (GameObject plat in fadingPlats) {
                plat.SetActive(true);
                plat.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = fullAlpha;
            }
        }
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class FadingTilemap : MonoBehaviour
{
    public float alphaLevel;
    public float fadeSpeed = 1f;
    public GameObject player;
    public Color OGColor;
    public Respawn rsp;
    // private SpriteRenderer rndr;
    // // Start is called before the first frame update
    void Start() {
        alphaLevel = 1f;
        player = GameObject.FindGameObjectWithTag("Player");
        OGColor = GetComponent<TilemapRenderer>().material.color;
        rsp = player.GetComponent<Respawn>();
        // rndr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.y < rsp.threshold) {
            GetComponent<TilemapRenderer>().material.color = OGColor;
        }
    }

    public void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Player"){
            Debug.Log("working");
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade() {
        while(this.GetComponent<TilemapRenderer>().material.color.a > 0) {
            Color startColor = this.GetComponent<TilemapRenderer>().material.color;
            float fadeLevel = startColor.a - (fadeSpeed * Time.deltaTime);

            startColor = new Color(startColor.r, startColor.g, startColor.b, fadeLevel);
            this.GetComponent<TilemapRenderer>().material.color = startColor;
            yield return null;
        }

        gameObject.SetActive(false);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFadingPlats : MonoBehaviour
{
    public float alphaLevel;
    public float fadeSpeed = 1f;

    public bool hidden;

    public GameHandler gameHandler;
    // private SpriteRenderer rndr;
    // // Start is called before the first frame update
    void Start() {
        alphaLevel = 1f;
        // rndr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {   
        // if(gameHandler.viewHiddenOn == true){
        //     Debug.Log("viewhidden is on");
        // } else {
        //     Debug.Log("viewhidden is not on");
        // }
        
        if (hidden) {
            if(gameHandler.viewHiddenOn) {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
            } else {
                gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            }
        } else {
            gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    public void OnCollisionEnter2D (Collision2D other){
        if (other.gameObject.tag == "Player"){
            Debug.Log("working");
            StartCoroutine(Fade());
        }
    }
    IEnumerator Fade() {
        while(this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color.a > 0) {
            Color startColor = this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
            float fadeLevel = startColor.a - (fadeSpeed * Time.deltaTime);

            startColor = new Color(startColor.r, startColor.g, startColor.b, fadeLevel);
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = startColor;
            yield return null;
        }

        gameObject.GetComponent<BoxCollider2D>().enabled = false;

        yield return new WaitForSeconds(0.5f);

        gameObject.GetComponent<BoxCollider2D>().enabled = true;

        while(this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color.a < 1) {
            Color startColor = this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color;
            float fadeLevel = startColor.a + (2 * fadeSpeed * Time.deltaTime);

            startColor = new Color(startColor.r, startColor.g, startColor.b, fadeLevel);
            this.transform.GetChild(0).GetComponent<SpriteRenderer>().material.color = startColor;
            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadingPlatform : MonoBehaviour
{
    public float alphaLevel;
    public float fadeSpeed = 1f;
    // private SpriteRenderer rndr;
    // // Start is called before the first frame update
    void Start() {
        alphaLevel = 1f;
        // rndr = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

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

        gameObject.SetActive(false);
    }
}

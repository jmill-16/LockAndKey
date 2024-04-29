using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PhasableWall : MonoBehaviour
{
    public GameHandler gameHandler;
    public bool superSpeed = false;
    public bool hiddenVision = false;
    public bool phasable = false;
    Color startColor;
    Color phaseableColor;

    public float alphaLevel;
    public float fadeSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        startColor = this.GetComponent<TilemapRenderer>().material.color;
        phaseableColor = new Color(startColor.r, startColor.g, startColor.b, 0.25f);
        alphaLevel = 1f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        superSpeed = gameHandler.speedOn;
        hiddenVision = gameHandler.viewHiddenOn;

        if (hiddenVision == true && this.tag == "Phaseable"){
            this.GetComponent<TilemapRenderer>().material.color = phaseableColor;
        } else {
            StartCoroutine(FadeIn());
        }

        if (superSpeed == true) {
            this.GetComponent<TilemapCollider2D>().enabled = false;
        } else {
            this.GetComponent<TilemapCollider2D>().enabled = true;
        }

        
    }

    IEnumerator FadeIn() {

        while(this.GetComponent<TilemapRenderer>().material.color.a < 1) {
            Color newColor = this.GetComponent<TilemapRenderer>().material.color;
            float fadeLevel = newColor.a + (fadeSpeed * Time.deltaTime);

            newColor = new Color(newColor.r, newColor.g, newColor.b, fadeLevel);
            this.GetComponent<TilemapRenderer>().material.color = newColor;
            Debug.Log("Alpha level is: " + this.GetComponent<TilemapRenderer>().material.color.a);
            yield return null;
        }
    }
}

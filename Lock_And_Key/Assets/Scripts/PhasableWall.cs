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

    // Start is called before the first frame update
    void Start()
    {
        startColor = this.GetComponent<TilemapRenderer>().material.color;
        phaseableColor = new Color(startColor.r, startColor.g, startColor.b, 0.25f);
    }

    // Update is called once per frame
    void Update()
    {
        superSpeed = gameHandler.speedOn;
        hiddenVision = gameHandler.viewHiddenOn;

        if (hiddenVision == true && this.tag == "Phaseable"){
            this.GetComponent<TilemapRenderer>().material.color = phaseableColor;
        } else {
            this.GetComponent<TilemapRenderer>().material.color = startColor;
        }

        if (superSpeed == true) {
            this.GetComponent<TilemapCollider2D>().enabled = false;
        } else {
            this.GetComponent<TilemapCollider2D>().enabled = true;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using TMPro;

public class keyCheckMaze : MonoBehaviour
{
    public GameHandler gameHandler;
    public bool canOpen;
    public TextMeshPro canOpenText;
    // Start is called before the first frame update
    void Start()
    {
        canOpenText = this.transform.GetChild(0).GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameHandler.canOpenDoor) {
            GetComponent<TilemapCollider2D>().enabled = false;
            GetComponent<TilemapRenderer>().enabled = false;
            canOpenText.enabled = false;
        }
    }
}

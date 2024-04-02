using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisappearingPlatform : MonoBehaviour
{   

    public float timeToTogglePlatform = 2;
    public float currentTime = 0;
    public bool enabled = true;

    private BoxCollider2D collider;
    

    // Start is called before the first frame update
    void Start()
    {
        enabled = true;
        collider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= timeToTogglePlatform) {
            currentTime = 0;
            TogglePlatform();
        }
    }

    void TogglePlatform() {
        enabled = !enabled;
        foreach(Transform child in gameObject.transform) {
            if (child.tag != "Player") {
                child.gameObject.SetActive(enabled);
            }
            
        }
        collider.enabled = !collider.enabled;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour
{
    public GameHandler gameHandler;

    private GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameHandler.viewHiddenOn) {
            platformSwitch(true);
        } else {
            platformSwitch(false);
        }
    }

    private void platformSwitch(bool active)
    {
        foreach(Transform child in this.transform) {
            if (child.gameObject.name == "Invisible2") {
                child.gameObject.SetActive(!active);
            } else {
                child.gameObject.SetActive(active);
            }
        }
    }
}

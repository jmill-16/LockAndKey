using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenObjects : MonoBehaviour
{
    public GameHandler gameHandler;
    public GameObject[] hiddenObjects;

    private bool hiddenOn = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        hiddenOn = gameHandler.viewHiddenOn;
        switchHidden(hiddenOn);
    }

    private void switchHidden(bool hiddenOn)
    {
        for (int i = 0; i < hiddenObjects.Length; i++) {
            hiddenObjects[i].SetActive(hiddenOn);
        }
    }
}

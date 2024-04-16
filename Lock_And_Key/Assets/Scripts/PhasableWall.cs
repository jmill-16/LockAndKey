using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhasableWall : MonoBehaviour
{
    public GameHandler gameHandler;
    public bool superSpeed = false;
    public bool hiddenVision = false;
    public bool phasable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        superSpeed = gameHandler.speedOn;
        hiddenVision = gameHandler.viewHiddenOn;
        phasable = hiddenVision;
    }
}

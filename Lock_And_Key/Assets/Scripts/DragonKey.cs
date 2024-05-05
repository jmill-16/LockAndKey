using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonKey : MonoBehaviour
{
    // Start is called before the first frame update
    //public int numDrag;

    public GameObject purple;
    public GameObject blue;

    public GameObject hiddenKey;
    void Start()
    {
        //numDrag = 2;
        hiddenKey.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if ( GameObject.FindGameObjectsWithTag("Enemy").Length == 0) {
        if (((!blue) && (!purple)) && hiddenKey){
            hiddenKey.SetActive(true);
        }
        
    }
}

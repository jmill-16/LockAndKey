using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemyHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameHandler gamehandler;

    public GameObject hiddenPurpleEnemy;
    public GameObject hiddenBlueEnemy;
    void Start()
    {
        gamehandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (hiddenPurpleEnemy) {
            if(gamehandler.viewPurpleOn){
                hiddenPurpleEnemy.SetActive(true);
            } else {
                 hiddenBlueEnemy.SetActive(true);
            }
        }

        if (hiddenBlueEnemy) {
            if(gamehandler.viewPurpleOn){
                 hiddenBlueEnemy.SetActive(false);
            } else {
                 hiddenBlueEnemy.SetActive(true);
            }
        }
    }
}

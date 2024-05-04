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
            if((gamehandler.selectedHiddenPower == false) && gamehandler.viewPurpleOn){
                hiddenPurpleEnemy.SetActive(true);
            } else {
                hiddenPurpleEnemy.SetActive(false);
            }
        }

        if (hiddenBlueEnemy) {
            if (!gamehandler.selectedHiddenPower && !gamehandler.viewPurpleOn){
                hiddenBlueEnemy.SetActive(true);
            } else {
                hiddenBlueEnemy.SetActive(false);
            }
        }
    }
}

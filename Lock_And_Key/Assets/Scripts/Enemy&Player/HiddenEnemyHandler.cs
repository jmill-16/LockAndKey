using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiddenEnemyHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public GameHandler gamehandler;

    public GameObject hiddenEnemy;
    void Start()
    {
        gamehandler = GameObject.FindGameObjectWithTag("GameHandler").GetComponent<GameHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamehandler.viewPurpleOn){
            hiddenEnemy.SetActive(true);
        } else {
            hiddenEnemy.SetActive(false);
        }
    }
}

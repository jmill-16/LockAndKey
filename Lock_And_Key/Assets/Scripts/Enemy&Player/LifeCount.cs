using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{

    public Image[] lives;
    public int livesRemaining;

    public void LoseLife()
    {
        if (livesRemaining == 0)
        {
            //play game over scene
            return;
        }

        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if(livesRemaining == 0)
        {
            Debug.Log("You lose");
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoseLife();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterDeathPlat : MonoBehaviour
{
    // Start is called before the first frame update
    public GameHandler gameHandler;

    public GameObject ghostBoss;
      //public playerVFX playerPowerupVFX;
    
    public GameObject ADPlat;
    public GameObject ADArrow;

    public bool notDestroyed = true;

      void Start(){
            gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
            ghostBoss = GameObject.FindWithTag("Enemy");
      }

      public void Update() {
        //hiddenObj.SetActive(true);
        if (ghostBoss == null) {
            ADPlat.SetActive(true);
            ADArrow.SetActive(true);
        } else {
            ADPlat.SetActive(false);
            ADArrow.SetActive(false);
        }
      }
}

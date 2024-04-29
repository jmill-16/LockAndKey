using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyEnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject key;
    public GameObject enemy;
    void Start()
    {
        key = GameObject.FindWithTag("Key");
        enemy = GameObject.FindWithTag("Enemy");

        key.SetActive(false);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((enemy == null) && key) {
            key.SetActive(true);
        }
        
    }
}

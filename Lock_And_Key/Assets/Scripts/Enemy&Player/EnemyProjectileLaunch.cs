using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform[] launchPoints;

    public float shootTime;
    public float shootCounter;

    private Animator enemyAnim;
    // Start is called before the first frame update
    void Start()
    {
        // if (GameObject.FindWithTag("Player") != null) {
            // playerAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
        // }
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCounter <= 0)
        {
            //if (playerAnim) {
                //playerAnim.SetTrigger("Attack");
            //}
            for (int i = 0; i < launchPoints.Length; i++) {
                Instantiate(projectilePrefab, launchPoints[i].position, Quaternion.identity);
            }
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}

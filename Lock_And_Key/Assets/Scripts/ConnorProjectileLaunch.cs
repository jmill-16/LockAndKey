using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnorProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;

    public float shootTime;
    public float shootCounter;

    private Animator playerAnim;
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Player") != null) {
            playerAnim = GameObject.FindWithTag("Player").GetComponentInChildren<Animator>();
        }
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && shootCounter <= 0)
        {
            if (playerAnim) {
                playerAnim.SetTrigger("Attack");
            }
            Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}

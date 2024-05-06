using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLaunch : MonoBehaviour
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
            //FireProjectile();
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;

        // void FireProjectile()
        // {
        //     Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //     Vector2 direction = (mousePosition - launchPoint.position).normalized;
        //     GameObject projectile = Instantiate(projectilePrefab, launchPoint.position, Quaternion.identity);
        // }
    }
}

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
    public float projectileSpeed = 10f; 
    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindWithTag("Enemy") != null) {
            enemyAnim = GameObject.FindWithTag("Enemy").GetComponentInChildren<Animator>();
        }
        shootCounter = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(shootCounter <= 0)
        {
            if (enemyAnim) {
                enemyAnim.SetTrigger("Fire");
            }
            for (int i = 0; i < launchPoints.Length; i++) {
                Vector2 direction = (launchPoints[i].position - this.gameObject.transform.position).normalized;
                GameObject projectile = Instantiate(projectilePrefab, launchPoints[i].position, Quaternion.identity);
                Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

                rb.velocity = direction * projectileSpeed;
            }
            shootCounter = shootTime;
        }
        shootCounter -= Time.deltaTime;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnorProjectileLaunch : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint; 
    public float projectileSpeed = 10f; 

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
    }

    void FireProjectile()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePosition - firePoint.position).normalized;
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        rb.velocity = direction * projectileSpeed;
    }
}
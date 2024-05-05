using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float lifetime = 2f; // Lifetime of the projectile in seconds

    public int damage;

    void Start()
    {
        damage = 10;
        // Destroy the projectile after its lifetime expires
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Player")
            {
                collision.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
}
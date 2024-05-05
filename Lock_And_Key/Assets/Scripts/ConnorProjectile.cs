using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnorProjectile : MonoBehaviour
{
    public float lifetime = 2f;

    public int damage;

    void Start()
    {
        damage = 10;
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
            }

            Destroy(gameObject);
        }
}
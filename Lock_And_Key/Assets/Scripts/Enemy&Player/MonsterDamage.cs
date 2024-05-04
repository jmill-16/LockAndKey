using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage; 
    // private Animator anim;
    public PlayerHealth playerHealth;

    void Start()
    {
        // anim = GetComponentInChildren<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // anim.SetBool("HasTarget", true);
            playerHealth.TakeDamage(damage);
        } 
        // anim.SetBool("HasTarget", false);
    }
}

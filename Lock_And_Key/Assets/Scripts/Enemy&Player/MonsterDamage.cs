using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public Animator anim;
    public int damage; 
    public PlayerHealth playerHealth;

    void Start() {
        anim = GetComponentInChildren<Animator> ();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("colliding with player");
            anim.SetTrigger("Attack");

            playerHealth.TakeDamage(damage);
        } else {
            Debug.Log("else");
            anim.SetTrigger("Walk");
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            anim.SetTrigger("Walk");
        }
    }

    // private void OnCollisionStay2D (Collision2D collision) {
    //     if(collision.gameObject.tag == "Player")
    //     {
    //         Debug.Log("colliding with player");
    //         anim.SetTrigger("Attack");
    //     } else {
    //         Debug.Log("else");
    //         anim.SetTrigger("Walk");
    //     }
    // }
}

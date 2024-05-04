using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float maxHealth = 100;
    // public int maxHealth;
    public float health;
    // public Image healthBar;

    //for death animation
    //public Animator anim;

    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        // maxHealth = health;
        health = maxHealth;

    }

    public void TakeDamage(int damage)
    {

        //play sound effect here

        health -=damage;
        if(health <= 0)
        {
            //Debug.Log("death animation");
            //anim.SetTrigger("Die");
            //Destroy(gameObject);

            StartCoroutine(playerDie());

            //play death animation here
            //anim.SetBool("IsDead", true);

            //show lose screen
        } else {
            Debug.Log("hurt animation");
            anim.SetTrigger("Hurt");
        }

        //Debug.Log("got hit");
    }


    IEnumerator playerDie()

	{

		Debug.Log("death animation");
        anim.SetTrigger("Die");



		yield return new WaitForSeconds(1.5f); // wait for 5 sec

		Destroy(gameObject);

	}

//for when we add healing to the game
    // public void Heal(int amount)
    // {
    //     health +=amount;
    //     if(health > maxHealth)
    //     {
    //         health = maxHealth;
    //     }
    // }

    void Update()
    {
        // healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        //healthBar.fillAmount = Mathf.Clamp(maxHealth / health, 0, 1);

    }

}

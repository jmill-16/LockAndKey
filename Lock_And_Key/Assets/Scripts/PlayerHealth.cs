using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //for lifecounter
    public Image[] lives;
    public int livesRemaining;

    public GameOver GameOver;
    // public Respawn Respawn;
    public Vector3 spawn = new Vector3(0,0,0);

    public float maxHealth = 100;
    public float health;

    //for death animation
    //public Animator anim;

    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        spawn = GameObject.FindGameObjectWithTag("SpawnPoint").transform.position;
        anim = GetComponentInChildren<Animator>();
        health = maxHealth;

    }

    public void TakeDamage(int damage)
    {

        //play sound effect here

        health -=damage;
        if(health <= 0)
        {
            LoseLife();
            //Debug.Log("death animation");
            //anim.SetTrigger("Die");
            //Destroy(gameObject);

            // StartCoroutine(playerDie());

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

        //gameover scene

	}

    public void LoseLife()
    {
        transform.position = spawn;
        if (livesRemaining == 10) {
            return;
        }
        if (livesRemaining <= 0)
        {
            //play game over scene
            GameOver.Setup();
            StartCoroutine(playerDie());
            return;
        }else{
            health = maxHealth;
        }

        livesRemaining--;

        lives[livesRemaining].enabled = false;

        if (livesRemaining <= 0)
        {
            //play game over scene
            GameOver.Setup();
            StartCoroutine(playerDie());
            return;
        }else{
            health = maxHealth;
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            LoseLife();
        }
    }

}

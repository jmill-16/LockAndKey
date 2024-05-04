using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public float maxHealth = 100;
    // public int maxHealth;
    public float health;

    public GameObject[] itemDrops;

    private Renderer rend;
    // public Image healthBar;
    // Start is called before the first frame update
    private Animator anim;
    void Start()
    {
        // maxHealth = health;
        health = maxHealth;
        rend = GetComponentInChildren<Renderer> ();
        anim = GetComponentInChildren<Animator>();

    }

    public void TakeDamage(int damage)
    {
        StartCoroutine(enemyDie());
        StopCoroutine("HitEnemy");
        StartCoroutine("HitEnemy");
        health -=damage;
        if(health <= 0)
        {
            StartCoroutine(enemyDie());
            ItemDrop();
        }
    }

    void Update()
    {
        // healthBar.fillAmount = Mathf.Clamp(health / maxHealth, 0, 1);
        // healthBar.fillAmount = Mathf.Clamp(maxHealth / health, 0, 1);

    }

    private void ItemDrop()
    {
        for (int i = 0; i < itemDrops.Length; i++) {
            Instantiate(itemDrops[i], transform.position + new Vector3(0, 1, 0), Quaternion.identity);
        }
    }

    IEnumerator HitEnemy(){
              // color values are R, G, B, and alpha, each divided by 100
              rend.material.color = new Color(2.4f, 0.9f, 0.9f, 0.5f);
              if (gameObject.GetComponent<EnemyHealth>().health < 1){
                     //gameControllerObj.AddScore (5);
                     Destroy(gameObject);
              }
              else yield return new WaitForSeconds(0.5f);
              rend.material.color = Color.white;
    }

    IEnumerator enemyDie()
	{

		//Debug.Log("death animation");
        if (anim != null){
            Debug.Log("death animation");
            anim.SetTrigger("Die");
        }



		yield return new WaitForSeconds(0.75f); // wait for 5 sec

		Destroy(gameObject);

	}

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{

    public int maxHealth = 100;
    // public int maxHealth;
    public int health;

    public GameObject[] itemDrops;
    // public Image healthBar;
    // Start is called before the first frame update
    void Start()
    {
        // maxHealth = health;
        health = maxHealth;

    }

    public void TakeDamage(int damage)
    {
        health -=damage;
        if(health <= 0)
        {
            Destroy(gameObject);
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

}

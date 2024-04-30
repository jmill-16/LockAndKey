using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Rigidbody2D projectileRb;
    public float speed;

    public float projectileLife;
    public float projectileCount;

    public PlayerMove playermove;
    public bool facingRight;


    public int damage; 
    public EnemyHealth enemyHealth;

    // Start is called before the first frame update
    void Start()
    {
        damage = 10;
        projectileCount = projectileLife;
        playermove = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMove>();
        facingRight = playermove.FaceRight;
        if(!facingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }
        
    }

    private void FixedUpdate()
        {
            if(facingRight) 
            {
                projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
            } else {
                projectileRb.velocity = new Vector2(-speed, projectileRb.velocity.y);

            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject.tag == "Enemy")
            {
                Debug.Log("take damage");
                collision.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                // Destroy(collision.gameObject);
            }

            Destroy(gameObject);
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if(col.gameObject.tag == "Enemy")
            {
                Debug.Log("take damage");
                col.gameObject.GetComponent<EnemyHealth>().TakeDamage(damage);
                // Destroy(collision.gameObject);
            }
        }
}

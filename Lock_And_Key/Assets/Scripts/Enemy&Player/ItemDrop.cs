using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{

    private Rigidbody2D itemRb;
    public float dropForce = 5;
    // Start is called before the first frame update
    void Start()
    {
        itemRb = GetComponent<Rigidbody2D>();
        itemRb.AddForce(Vector2.up * dropForce, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with an object tagged as "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the item GameObject
            Destroy(gameObject);
        }
    }
}

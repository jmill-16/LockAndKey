using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour
{
    // This function is called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collided object has the "Item" tag
        if (other.CompareTag("Item"))
        {
            // Destroy the collided item GameObject
            Destroy(other.gameObject);
        }
    }
}

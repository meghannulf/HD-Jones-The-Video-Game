using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWithBullets : MonoBehaviour
{
    // Counter for the number of bullets hitting the GameObject
    private int bulletCount = 0;

    // OnCollisionEnter is called when a collision with another collider occurs
    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with a bullet
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Increment the bullet count
            bulletCount++;

            // Check if bullet count reaches 100
            if (bulletCount >= 100)
            {
                // Destroy the GameObject
                Destroy(gameObject);
            }
        }
    }
}

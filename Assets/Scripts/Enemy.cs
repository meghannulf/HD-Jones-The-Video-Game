using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    [SerializeField] public float speed = 3f;
    [SerializeField] private float RotateSpeed = 0.0025f;
    private static Enemy _instance;
    public static Enemy Instance { get { return _instance; } }
    private Rigidbody2D rb;
    private int EnemyHealth = 3;
    //Meghan codeline
    public AudioSource enemyNoise;
    public AudioSource championSound;
    public static int totalEnemies; //Total number of enemies in the scene
    private static int enemiesDefeated; //Number of enemies defeated


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Meghan code
        AudioSource[] audioSources = GetComponents<AudioSource>();
        if (audioSources.Length >= 2)
        {
            enemyNoise = audioSources[0];
            championSound = audioSources[1];
        }
    }

    //Meghan code
    private void OnDestroy()
    {
        // Decrement totalEnemies when an enemy is destroyed
        totalEnemies--;

        // Check if all enemies are defeated
        if (totalEnemies == 0)
        {
            // Play the champion sound
            if (championSound != null)
            {
                championSound.Play();
            }
        }
    }

    private void Update()
    {
        //get the target
        if (!target)
        {
            GetTarget();
        }
        else
        {
            RotateTowardsTarget();
        }
    }

    private void RotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, RotateSpeed);
    }

    private void FixedUpdate() 
    {
        // Move forwards
        rb.velocity = transform.up * speed;
    }

    private void GetTarget()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // healthbar.SetHealth(health - 10);
            Destroy(other.gameObject);
            target = null;

        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyHealth--;
            //Meghan code
            enemyNoise.Play();
            Debug.Log("Bullet Hit");

            Destroy(other.gameObject);
            if (EnemyHealth == 0)
            {
                Destroy(gameObject);
            } 
        }
       
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    [SerializeField] public float speed = 3f;
    [SerializeField] private float RotateSpeed = 0.0025f;
    private Rigidbody2D rb;
    private int EnemyHealth = 3;
    //Meghan codeline
    private AudioSource enemy_noise;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //Meghan code
        enemy_noise = GetComponent<AudioSource>();
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
            enemy_noise.Play();

            Destroy(other.gameObject);
            if (EnemyHealth == 0)
            {
                Destroy(gameObject);
            } 
        }
       
    }
}

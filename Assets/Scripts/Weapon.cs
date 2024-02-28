using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{   //K's weapon class 
    public GameObject bulletPrefab; 
    public Transform firePoint; 
    public float fireForce = 20f; 

    public bool isFiring = false; 

    public void StartFiring(){ 
        isFiring = true; 
        StartCoroutine(FireCoroutine()); 
    }

    public void StopFiring() { 
        isFiring = false; 
    }
    public void Fire() { 
        GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
        Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse); 
    } 

    IEnumerator FireCoroutine() { 
        while (isFiring) { 
            Fire(); 
            yield return new WaitForSeconds(0.1f); //Adjust the delay between shots 
        }
    }
}

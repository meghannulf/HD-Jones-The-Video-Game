using System.Collections;
using UnityEngine;
using Playerspace;

public class Weapon : MonoBehaviour
{
    // Reference to the player controller
    private PlayerController playerController;

    //K's weapon class 
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireForce = 20f;

    public bool isFiring = false;

    public float bulletLifetime = 3f;

    // Initialize the weapon with the player controller reference
    public void Initialize(PlayerController controller)
    {
        playerController = controller;
    }

    public void StartFiring()
    {
        isFiring = true;
        playerController.StartCoroutine(FireCoroutine());
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void Fire()
    {
        GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
        bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

        // Destroy bullet after a certain amount of time
        GameObject.Destroy(bullet, bulletLifetime);
    }

    private IEnumerator FireCoroutine()
    {
        while (isFiring)
        {
            Fire();
            yield return new WaitForSeconds(0.1f); // Adjust the delay between shots
        }
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Weapon : MonoBehaviour
// {   //K's weapon class 
//     public GameObject bulletPrefab; 
//     public Transform firePoint; 
//     public float fireForce = 20f; 

//     public bool isFiring = false; 

//     public float bulletLifetime = 3f; 
//     public void StartFiring(){ 
//         isFiring = true; 
//         StartCoroutine(FireCoroutine()); 
//     }

//     public void StopFiring() { 
//         isFiring = false; 
//     }
//     public void Fire() { 
//         GameObject Bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation); 
//         Bullet.GetComponent<Rigidbody2D>().AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

//         //Destroy bullet after a certain amount of time 
//         Destroy(Bullet, bulletLifetime);  
//     } 

//     IEnumerator FireCoroutine() { 
//         while (isFiring) { 
//             Fire(); 
//             yield return new WaitForSeconds(0.1f); //Adjust the delay between shots 
//         }
//     }
// }


// using System.Collections;
// using UnityEngine;

// namespace Weaponspace
// {
//     public class Weapon
//     {
//         //K's weapon class 
//         public GameObject bulletPrefab;
//         public Transform firePoint;
//         public float fireForce = 20f;

//         public bool isFiring = false;

//         public float bulletLifetime = 3f;

//         public void StartFiring(MonoBehaviour monoBehaviour)
//         {
//             isFiring = true;
//             monoBehaviour.StartCoroutine(FireCoroutine());
//         }

//         public void StopFiring()
//         {
//             isFiring = false;
//         }

//         public void Fire()
//         {
//             GameObject bullet = GameObject.Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
//             Rigidbody2D bulletRb = bullet.GetComponent<Rigidbody2D>();
//             bulletRb.AddForce(firePoint.up * fireForce, ForceMode2D.Impulse);

//             // Destroy bullet after a certain amount of time
//             GameObject.Destroy(bullet, bulletLifetime);
//         }

//         private IEnumerator FireCoroutine()
//         {
//             while (isFiring)
//             {
//                 Fire();
//                 yield return new WaitForSeconds(0.1f); // Adjust the delay between shots
//             }
//         }
//     }
// }

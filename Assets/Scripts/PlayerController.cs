using System.Collections;
using System.Collections.Generic;
//using System.Numerics; commented out due to Vector2 conflicts with InputSystem pkg
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //For movement; done by Matt 
    public float moveSpeed = 1f;
    public float collisionOffset = 0.05f;
    public ContactFilter2D movementFilter;
    Vector2 movementInput;
    Rigidbody2D rb; //also used for shooting ammo
    List<RaycastHit2D> castCollisions = new List<RaycastHit2D>();

    //For Shooting hot dogs; done by K 
    public Weapon weapon; 
    Vector2 moveDirection; 
    Vector2 mousePosition; 
    //private bool isFiring = false; //Tracks whether firing is in progress 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    //K's section for shooting ammo 

    public bool isFiring = false; 

    public void StartFiring(){ 
        isFiring = true; 
        StartCoroutine(FireCoroutine()); 
    }

    public void StopFiring() { 
        isFiring = false; 
    }

    IEnumerator FireCoroutine() { 
        while (isFiring) { 
            weapon.Fire(); 
            yield return new WaitForSeconds(0.3f); //Adjust the delay between shots 
        }
    }
    void Update() { 
        float moveX = Input.GetAxisRaw("Horizontal"); 
        float moveY = Input.GetAxisRaw("Vertical"); 

        if(Input.GetKeyDown(KeyCode.Space)) {
            StartFiring(); 
        }
        else if (Input.GetKeyUp(KeyCode.Space)) { 
            StopFiring(); 
        }
        moveDirection = new Vector2(moveX, moveY).normalized; 
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
    }

    private void FixedUpdate() 
    {
        // if movement input is not 0, try to move - Matt
        if (movementInput != Vector2.zero) {
            int count = rb.Cast(movementInput, movementFilter, castCollisions, moveSpeed * Time.fixedDeltaTime + collisionOffset);
            if (count == 0) {
                rb.MovePosition(rb.position + movementInput * moveSpeed * Time.fixedDeltaTime);
            }
        }  

        // handle physics calcs for shooting - K 
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed); 
        Vector2 aimDirection = mousePosition - rb.position; //Calculating angle based on mouse pos
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f; 
        rb.rotation = aimAngle; 
    }

    void OnMove(InputValue movementValue) {
        movementInput = movementValue.Get<Vector2>();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDJAnimation : MonoBehaviour
{
    public float moveSpeed = 5f; // Speed of movement
    public Color idleColor = Color.white; // Color when not moving
    public Color movingColor = Color.gray; // Color when moving
    public Color leftColor = Color.red; // Color when moving left
    public Color rightColor = Color.green; // Color when moving right
    public Color upColor = Color.blue; // Color when moving up
    public Color downColor = Color.yellow; // Color when moving down

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = idleColor; // Set initial color to idle color
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the circle
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * moveSpeed;
        rb.velocity = movement;

        // Change color based on movement direction or idle
        if (movement != Vector2.zero)
        {
            if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
            {
                // Horizontal movement
                if (movement.x > 0)
                {
                    spriteRenderer.color = rightColor;
                }
                else
                {
                    spriteRenderer.color = leftColor;
                }
            }
            else
            {
                // Vertical movement
                if (movement.y > 0)
                {
                    spriteRenderer.color = upColor;
                }
                else
                {
                    spriteRenderer.color = downColor;
                }
            }
        }
        else
        {
            spriteRenderer.color = idleColor;
        }
    }
}

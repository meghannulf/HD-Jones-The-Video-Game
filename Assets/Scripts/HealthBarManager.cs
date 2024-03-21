using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthBarManager : MonoBehaviour
{
    public int maxHealth = 100;
    public int minHealth = 0;
    public int currentHealth;
    public healthbar healthBar;
    public HotdogAnimatorController player; 


    public void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public void FixedUpdate()
    {
        // You can handle other player input or events here if needed

    }

    // Call this function to apply damage and handle collisions with obstacles
    public void HandleCollisions(Collision2D collision)
    {
        if (collision.transform.tag == "Bullet")
        {
            TakeDamage(10);
            Destroy(collision.gameObject); // Destroy the obstacle
            if (currentHealth <= 0)
            {
               LeaveTheGame();
               //SceneManager.LoadScene("GameOver"); // Load the "GameOver" scene when health is 0 or below
            }
        }
    }

    void TakeDamage(int damage)
    {
        if (currentHealth < 20)
        {
            currentHealth = 0;
            healthBar.SetHealth(currentHealth);

            // Access the Entity script to change the state to deadState
            HotdogAnimatorController player = GetComponent<HotdogAnimatorController>();
            if (player != null)
            {
                //player.currentState = player.deadState;
            }

            // Additional logic if needed, e.g., play death animation, disable controls, etc.
            Animator animator = GetComponent<Animator>();
            if (animator != null)
            {
                //animator.runtimeAnimatorController = player.MushrioDead as RuntimeAnimatorController;
            }

            // Wait for 5 seconds before loading the game over scene
            StartCoroutine(LoadGameOverSceneAfterDelay(2.5f));
        }
        else
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
        }
    }
    private IEnumerator LoadGameOverSceneAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        // Load the game over scene
        //SceneManager.LoadScene("GameOver"); 
    }

    //using this instead of game over scene for now
     public void LeaveTheGame(){
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }
}

using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour
{
    private bool isPlayerFrozen = false;
    private float freezeDuration = 0.2f;

    // Define a method to handle collision with the player
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object is the player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Perform actions when the player collides with the obstacle
            Debug.Log("Player collided with " + gameObject.name);

            //// Freeze the player
            //StartCoroutine(FreezePlayer(collision.gameObject));
        }
    }
}
//    // Coroutine to freeze the player for a short duration
//    private IEnumerator FreezePlayer(GameObject player)
//    {
//        if (!isPlayerFrozen)
//        {
//            isPlayerFrozen = true;

//            // Example: you could stop player movement here
//            // player.GetComponent<PlayerController>().FreezeMovement();

//            // Wait for the specified duration
//            yield return new WaitForSeconds(freezeDuration);

//            // Example: resume player movement here
//            // player.GetComponent<PlayerController>().ResumeMovement();

//            isPlayerFrozen = false;
//        }
//    }
//}

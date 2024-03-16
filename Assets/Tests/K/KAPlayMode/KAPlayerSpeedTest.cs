/*
* Filename: KAPlayerSpeedTest.cs
* Developer: K Atkinson
* Purpose: Test the breaking point of obstacles when player impacts at certain speed 
*/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class KAPlayerSpeedTest
{
    //Assign 
    public static GameObject player;
    public static Rigidbody2D playerRb;
    public static GameObject obstacle;

    [SetUp]
    public void Setup()
    {
        // load dummy scene
        SceneManager.LoadScene("TestingScene");
    }

    //Act 
    [UnityTest]
    public IEnumerator TestPlayerSpeedOnCollision()
    {
        // Load or instantiate the player prefab
        GameObject player = GameObject.FindGameObjectWithTag("Player"); //Try another function for in-scene 
        playerRb = player.GetComponent<Rigidbody2D>();

        // Load or instantiate the obstacle prefab
        obstacle = GameObject.FindGameObjectWithTag("Obstacle");
        // Set player's velocity to a high speed (you can adjust this according to your needs)
        playerRb.velocity = Vector2.up * 100000f;

        // Adjust collider positions to ensure collision
        CircleCollider2D playerCollider = player.GetComponent<CircleCollider2D>();
        BoxCollider2D obstacleCollider = obstacle.GetComponent<BoxCollider2D>();
        Vector2 offset = new Vector2(0f, 10f); // Adjust offset according to collider size
        playerCollider.offset += offset;
        obstacleCollider.offset -= offset;

        // Wait for player to collide with obstacle
        yield return new WaitUntil(() => player.GetComponent<Collider2D>().IsTouching(obstacle.GetComponent<Collider2D>()));

        // Check the player's speed upon collision
        float playerSpeed = playerRb.velocity.magnitude;
        Debug.Log("Player Speed on Collision: " + playerSpeed);

        //Assert
        // The player's speed is within an acceptable range
        Assert.LessOrEqual(playerSpeed, 100000f); // Adjust the maximum speed limit as needed
    }
}



  

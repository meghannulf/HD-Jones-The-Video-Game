/*
* Filename: KAPlayerGrowthTest.cs
* Developer: K Atkinson
* Purpose: Test the growth of the player, busting the boundaries of the game. 
*/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class KAPlayerGrowthTest
{
    public static GameObject player;
    public static Vector3 initialScale;
    public static Vector3 screenPoint; 
    private const float GrowthRate = 0.1f; // Rate at which the player grows per frame

    [SetUp]
    public void Setup()
    {
        // load dummy scene
        SceneManager.LoadScene("TestingScene");

    }

    [UnityTest]
    public IEnumerator TestPlayerGrowth()
    {
        // Load or instantiate the player prefab
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Assert.IsNotNull(player, "Player not found in the scene.");

        // Store initial scale of the player
        initialScale = player.transform.localScale;
        // Start growing the player
        while (true)
        {
            // Increase player's scale
            player.transform.localScale += Vector3.one * GrowthRate;
            Vector3 screenPoint = Camera.main.WorldToViewportPoint(player.transform.position);
            // Check if player has grown beyond boundaries
            if (screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1)
            {
                Debug.Log("Player busted out of boundaries!");
                break;
            }

            yield return null;
        }
    }

    // public bool IsPlayerOutOfBounds()
    // {
    //     // Assuming the boundaries of the game are defined by the screen edges
    //     Vector3 screenPoint = Camera.main.WorldToViewportPoint(player.transform.position);
    //     return screenPoint.x < 0 || screenPoint.x > 1 || screenPoint.y < 0 || screenPoint.y > 1;
    // }

    [TearDown]
    public void Teardown()
    {
        // Reset player's scale to initial scale after the test
        //player.transform.localScale = initialScale;
    }
}


using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AnimationStressTest : MonoBehaviour
{
    public GameObject playerPrefab; 
    private const int NumPlayers = 1000;

    [SetUp]
    public void Setup()
    {
        // Load the player prefab from resources
        playerPrefab = Resources.Load<GameObject>("Player"); 
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab not found in resources!");
        }

         // Load dummy scene
        SceneManager.LoadScene("Andrew's Test Scene");

    }

    [UnityTest]
    public IEnumerator AnimationStress()
    {
        // Wait for the next frame
        yield return null;

        // Spawn multiple players
        for (int i = 0; i < NumPlayers; i++)
        {
            // Instantiate a player prefab
            GameObject player = Object.Instantiate(playerPrefab);

            player.name = "Player" + i; 
            // Wait for a short duration before spawning the next player
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
        Assert.True(false); // Something went wrong

        SceneManager.LoadScene("SampleScene");
    }
}
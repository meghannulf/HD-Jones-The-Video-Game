using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class JWStressTest
{
    GameObject kpPrefab;
    float initialSpawnDelay = 0.1f; // Initial delay between spawns
    float minSpawnDelay = 0.001f; // Minimum delay between spawns
    float spawnRateIncrease = 0.001f; // Rate at which spawn delay decreases
    float currentSpawnDelay;
    float currentFPS;

    [SetUp]
    public void Setup()
    {
        // Load the "KP" prefab
        kpPrefab = Resources.Load<GameObject>("Jon/KP");

        // Load the test scene
        SceneManager.LoadScene("JonTestScene");
    }

    [UnityTest]
    public IEnumerator JWStressWithEnumeratorPasses()
    {
        int spawnCount = 0;
        List<GameObject> spawnedInstances = new List<GameObject>(); // List to store spawned instances
        currentSpawnDelay = initialSpawnDelay;

        // Continuously update the frame rate and spawn prefabs
        while (true)
        {
            // Calculate current FPS
            currentFPS = 1f / Time.deltaTime;

            // Stop spawning if frame rate drops below 10
            if (currentFPS < 10)
                break;

            // Spawn the "KP" prefab at a random position within the camera's view
            Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.nearClipPlane + 1));
            GameObject kpInstance = Object.Instantiate(kpPrefab, spawnPosition, Quaternion.identity);
            spawnedInstances.Add(kpInstance); // Add spawned instance to the list
            spawnCount++;

            // Decrease the spawn delay to increase the spawn rate
            currentSpawnDelay = Mathf.Max(minSpawnDelay, currentSpawnDelay - spawnRateIncrease);

            // Wait for the next spawn with the adjusted delay
            yield return new WaitForSecondsRealtime(currentSpawnDelay);
        }

        // Clean up spawned instances
        foreach (var instance in spawnedInstances)
        {
            if (instance != null)
                Object.Destroy(instance);
        }

        // Output the spawn count when the test ends
        Debug.Log("Total Spawn Count: " + spawnCount);
        Debug.Log("Delay: " + currentSpawnDelay);
        Debug.Log("FPS: " + currentFPS);
    }
}

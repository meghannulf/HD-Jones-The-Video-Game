using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class JWMax
{
    [SetUp]
    public void setup()
    {
        // Load the test scene
        SceneManager.LoadScene("TestingScene");
    }

    [UnityTest]

    public IEnumerator JWMaxWithEnumeratorPasses()
    {
       

        // Wait for one frame to ensure scene is loaded
        yield return null;

        // Access all "KP" prefabs in the scene
        GameObject[] kpPrefabs = GameObject.FindGameObjectsWithTag("PowerUp");

        // Check if no more than 4 "KP" prefabs have spawned
        if (kpPrefabs.Length > 4)
        {
            Assert.Fail("More than 4 KP prefabs have spawned!");
        }
        else
        {
            Assert.Pass("No more than 4 KP prefabs have spawned.");
        }
        yield return null;
    }
}


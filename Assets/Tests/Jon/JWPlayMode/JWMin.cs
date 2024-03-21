using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class JWMin
{
    [SetUp]
    public void setup()
    {
        // Load the test scene
        SceneManager.LoadScene("TestingScene");
    }

    [UnityTest]

    public IEnumerator JWMinWithEnumeratorPasses()
    {


        // Wait for one frame to ensure scene is loaded
        yield return null;

        // Access all "KP" prefabs in the scene
        GameObject[] kpPrefabs = GameObject.FindGameObjectsWithTag("PowerUp");

        // Check if no more than 4 "KP" prefabs have spawned
        if (kpPrefabs.Length < 3)
        {
            Assert.Fail("Less than 3 KP prefabs have spawned!");
        }
        else
        {
            Assert.Pass("More than 3 KP prefabs have spawned!");
        }
        yield return null;
    }
}
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class MaxBoundMeg
{
    [SetUp]
    public void setup()
    {
        // Load the test scene
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]

    public IEnumerator Meg_Max()
    {
        yield return null;

        //obstacle prefabs initialization
        GameObject[] Obsfabs = GameObject.FindGameObjectsWithTag("obstacle");

        // Check if no more than 4 spawned
        if (Obsfabs.Length > 4)
        {
            Assert.Fail("More than 4 spawned");
        }
        else
        {
            Assert.Pass("No more than 4 spawned.");
        }
        yield return null;
    }
}


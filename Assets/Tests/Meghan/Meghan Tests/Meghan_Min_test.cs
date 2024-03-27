using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class MinBoundMeg
{
    [SetUp]
    public void setup()
    {
        // Load the test scene
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]

    public IEnumerator Meg_Min()
    {

        yield return null;

        GameObject[] Obsfabs = GameObject.FindGameObjectsWithTag("obstacle");

        if (Obsfabs.Length <= 4)
        {
            Assert.Pass("Less or 4 spawned");
        }
        else
        {
            Assert.Fail("Fail");
        }
        yield return null;
    }
}


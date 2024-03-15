/*
* Filename: BulletStressTest.cs
* Developer: K Atkinson
* Purpose: Stress testing unity with the creation of GameObjects
*/

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

// logged 9073 of instances before freezing
public class BulletStressTest
{
    /*
    * Summary: Sets up the scene for testing
    */
    [SetUp]

    public void Setup()
    {   // load dummy scene
        SceneManager.LoadScene("TestingScene");
    }

    /*
    * Summary: test should effectively spawn multiple player GameObjects into a dummy platformer level until Unity breaks
    */
    [UnityTest]
    public IEnumerator StressTestBullet()
    {   
        // create bullet object to instantiate
        GameObject bulletObj = new GameObject("Bullet", typeof(BoxCollider2D), typeof(SpriteRenderer));
        int i = 0; 
        // repeatedly spawn bulletObj
        while (i < int.MaxValue){
            GameObject.Instantiate(bulletObj); // make a new instance, increment the counter i, log the amount of instances
            i++;
            Debug.Log(i + " instances of bulletObj created.");
            yield return null;
        }
        yield return null; // should freeze before ever reaching here
        Assert.True(false); // if it does reach here then something went wrong with the test
    }

    [TearDown]
    public void Teardown()
    {
        SceneManager.UnloadSceneAsync("TestingScene");
    }
}
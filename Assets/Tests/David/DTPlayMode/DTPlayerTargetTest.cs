using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

public class PlayerTargetTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestingScene");
    }
    
    [UnityTest] //creates 100 players and has enemies target the
    public IEnumerator TestPlayerTarget()
    {
        int targetCount = 0;
        
        for (int i = 0; i < 100; i++)
        {
            GameObject playerObj = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            Debug.Log((i + 1) + " instances of playerObj created.");
            
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                targetCount++;
                Debug.Log(targetCount + " instances of playerObj targeted.");
            }
            
            MyDestroyer.DestroyObject(playerObj);
            yield return null;
        }

        Assert.AreEqual(100, targetCount); // Assert that all players were targeted
    }

    [TearDown]
    public void Teardown()
    {
    }
}

public class MyDestroyer {
    public static void DestroyObject(GameObject obj) {
        if(obj != null) {
            GameObject.Destroy(obj);
        }
    }
}
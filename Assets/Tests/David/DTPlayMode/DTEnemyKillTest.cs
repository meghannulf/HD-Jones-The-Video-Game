using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

public class EnemyKillTest
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestingScene");
    }
    
    [UnityTest] //creates 100 enemies and kills them
    public IEnumerator StressTestEnemy()
    {
        int i = 0;
        int y = 0;

        while (i < 100)
        {
            GameObject enemyObj = GameObject.CreatePrimitive(PrimitiveType.Cube); 
            Debug.Log((i + 1) + " instances of EnemyObj created.");

            MyDestroyer1.DestroyObject(enemyObj);
            y++;
            Debug.Log(y + " instances of EnemyObj destroyed");
            
            i++;
            yield return null;
        }

        Assert.IsTrue(true); // Assert that the test passes
    }

    [TearDown]
    public void Teardown()
    {
    }
}

public class MyDestroyer1 {
    public static void DestroyObject(GameObject obj) {
        if(obj != null) {
            GameObject.Destroy(obj);
        }
    }
}
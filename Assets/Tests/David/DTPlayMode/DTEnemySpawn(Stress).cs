using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using UnityEditor;

public class DTEnemySpawnStress
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestingScene");
    }
    
    //Test will spawn enemies until it crashes and report results
    [UnityTest]
    public IEnumerator StressTestEnemy()
    {
        GameObject enemyObj = new GameObject("Treevle", typeof(BoxCollider2D), typeof(SpriteRenderer));
        int i = 0;
        
        while (i < int.MaxValue){
            GameObject.Instantiate(enemyObj); 
            i++;
            Debug.Log(i + " instances of EnemyObj created.");
            yield return null;
        }
        yield return null; 

       
        Assert.True(false); 
    }

    [TearDown]
    public void Teardown()
    {
    }
}
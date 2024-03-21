using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NUnit.Framework;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System;
using System.Collections;
using System.Collections.Generic;


public class EnemyKillTest : MonoBehaviour
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestingScene");
    }
    
    //Test will spawn enemies and kill them 100 times and report results
    [UnityTest]
    public IEnumerator StressTestEnemy()
    {
        GameObject enemyObj = new GameObject("Treevle", typeof(BoxCollider2D), typeof(SpriteRenderer));
        int i = 0;
        int y = 0;
        
        while (i < 100){
            GameObject.Instantiate(enemyObj); 
            i++;
            Debug.Log(i + " instances of EnemyObj created.");
            Destroy(enemyObj);
            y++;
            Debug.Log(y + "instances of EnemyObj destroyed" );
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
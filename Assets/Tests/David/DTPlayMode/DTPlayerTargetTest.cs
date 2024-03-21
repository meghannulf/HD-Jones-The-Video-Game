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


public class PlayerTargetTest : MonoBehaviour
{
    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("TestingScene");
    }
    
    //Test will spawn 100 players and the enemy will have to target them all for it to pass
    [UnityTest]
    public IEnumerator TestPlayerTarget()
    {
        GameObject playerObj = new GameObject("Player", typeof(BoxCollider2D), typeof(SpriteRenderer));
        int i = 0;
        int y = 0;
        
        while (i < 100){
            GameObject.Instantiate(playerObj); 
            i++;
            Debug.Log(i + " instances of playerObj created.");
            
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                y++;
                Debug.Log(y + " instances of playerObj targeted.");
            }
            Destroy(playerObj);
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
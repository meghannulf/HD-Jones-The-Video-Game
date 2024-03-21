using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RebHealthBarTest
{
    [UnityTest]
    public IEnumerator HealthStressTestWithEnumeratorPasses()
    {
        float space = 0.1f;
        int objectNum = 1000;

        GameObject health = Resources.Load<GameObject>("Tests/HealthBar");

        for(int i = 0; i < objectNum; i++){

            Vector3 randomPosition = new Vector3(Random.Range(-(space * i),space * i),Random.Range(space * i,space * i));    
        
            GameObject.Instantiate(health, randomPosition, Quaternion.identity);

            yield return null;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RebLowBoundryTest
{
    [Test]
    public void PlayerHealthDoesNotExceedMin(){

        GameObject gameObject = new GameObject();
        HealthBarManager healthBarManager = gameObject.AddComponent<HealthBarManager>();
        Assert.AreEqual(0f, healthBarManager.minHealth);
   }
}

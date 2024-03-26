using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class NewTestScript
{
    [Test]
    public void PlayerHealthDoesNotExceedMax(){

         GameObject gameObject = new GameObject();
        HealthBarManager healthBarManager = gameObject.AddComponent<HealthBarManager>();
        Assert.AreEqual(100f, healthBarManager.maxHealth);
   }
}

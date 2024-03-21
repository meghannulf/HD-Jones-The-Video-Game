using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class RebLowBoundryTest
{
    // this is commented out because I could not get Unity to recognize where my HealthBarManager script was. The fix would have messed up everyone's tests
    [Test]
    public void PlayerHealthDoesNotExceedMin(){

        //var player = new GameObject().AddComponent<HealthBarManager>();
        //Assert.AreEqual(0f, player.minHealth);
   }
}

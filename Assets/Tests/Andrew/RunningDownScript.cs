/* 
 * Filename: RunningDownScript.cs
 * Developer: Andrew Bonilla
 * Purpose: Testing animation state parameters
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class RunningDownTestScript
{
    private HotdogAnimatorController hotdogController;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Andrew's Test Scene");
    }

    [UnityTest]
    public IEnumerator RunningDownAnimatorParameterIsSetCorrectly()
    {
        // Arrange
        GameObject hotdogGameObject = GameObject.FindGameObjectWithTag("Player");
        HotdogAnimatorController hotdogController = hotdogGameObject.AddComponent<HotdogAnimatorController>();
         

        // Act
        MovingDownState movingDownState = new MovingDownState(hotdogController);
        hotdogController.SetState(movingDownState);

        // Yield to allow one frame for the animator to update
        yield return new WaitForSeconds(5f);

        // Assert
        Animator animator = hotdogController.GetAnimator();
        Assert.IsTrue(animator.GetBool("RunningDown"), "RunningDown parameter should be true when in MovingDownState");
    }
}
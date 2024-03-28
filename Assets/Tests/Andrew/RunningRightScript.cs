/* 
 * Filename: RunningLeftScript.cs
 * Developer: Andrew Bonilla
 * Purpose: Testing animations state parameters 
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class RunningRightTestScript
{
    private HotdogAnimatorController hotdogController;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Andrew's Test Scene");
    }

    [UnityTest]
    public IEnumerator RunningRightAnimatorParameterIsSetCorrectly()
    {
        // Arrange
        GameObject hotdogGameObject = GameObject.FindGameObjectWithTag("Player");
        HotdogAnimatorController hotdogController = hotdogGameObject.AddComponent<HotdogAnimatorController>();


        // Act
        MovingRightState movingRightState = new MovingRightState(hotdogController);
        hotdogController.SetState(movingRightState);

        // Yield to allow one frame for the animator to update
        yield return new WaitForSeconds(5f);

        // Assert
        Animator animator = hotdogController.GetAnimator();
        Assert.IsTrue(animator.GetBool("RunningRight"), "RunningRight parameter should be true when in MovingRightState");
    }
}
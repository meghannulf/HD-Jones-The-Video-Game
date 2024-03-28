/* 
 * Filename: RunningUpScript.cs
 * Developer: Andrew Bonilla
 * Purpose: Testing animations state parameters 
 */

using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class RunningUpTestScript
{
    private HotdogAnimatorController hotdogController;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("Andrew's Test Scene");
    }

    [UnityTest]
    public IEnumerator RunningUpAnimatorParameterIsSetCorrectly()
    {
        // Arrange
        GameObject hotdogGameObject = GameObject.FindGameObjectWithTag("Player");
        HotdogAnimatorController hotdogController = hotdogGameObject.AddComponent<HotdogAnimatorController>();


        // Act
        MovingUpState movingUpState = new MovingUpState(hotdogController);
        hotdogController.SetState(movingUpState);

        // Yield to allow one frame for the animator to update
        yield return new WaitForSeconds(5f);

        // Assert
        Animator animator = hotdogController.GetAnimator();
        Assert.IsTrue(animator.GetBool("RunningUp"), "RunningUp parameter should be true when in MovingUpState");
    }
}
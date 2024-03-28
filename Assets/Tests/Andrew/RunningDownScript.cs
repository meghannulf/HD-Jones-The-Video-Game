/* 
 * Filename: RunningDownScript.cs
 * Developer: Andrew Bonilla
 * Purpose: Testing animations with different variables
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
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]
    public IEnumerator RunningDownBool()
    {
        // Arrange
        GameObject hotdogGameObject = GameObject.FindGameObjectWithTag("Player");
        hotdogController = hotdogGameObject.GetComponent<HotdogAnimatorController>();

        bool initialRunningDownValue = hotdogController.GetAnimator().GetBool("RunningDown");

        // Act
        hotdogController.GetAnimator().SetBool("RunningDown", !initialRunningDownValue);
        hotdogController.SetState(new MovingDownState(hotdogController));

        // Move player down for a brief period to ensure animation is or isn't playing
        yield return new WaitForSeconds(5f);

        // Assert 
        Assert.IsFalse(hotdogController.GetAnimator().GetCurrentAnimatorStateInfo(0).IsName("RunningDown"));
        Assert.AreEqual(!initialRunningDownValue, hotdogController.GetAnimator().GetBool("SetRunningDown"));

    }
}

using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class AnimationTriggerTest
{
    private GameObject playerPrefab;
    private Animator playerAnimator;

    [SetUp]
    public void Setup()
    {
        // Load the sample scene
        SceneManager.LoadScene("SampleScene");

        // Load the player prefab from resources
        playerPrefab = Resources.Load<GameObject>("Player"); 
        if (playerPrefab == null)
        {
            Debug.LogError("Player prefab not found in resources!");
        }

        // Get the Animator component attached to the player object
        playerAnimator = playerPrefab.GetComponent<Animator>();
        Assert.IsNotNull(playerAnimator, "Animator component not found on the player object");
    }

    [UnityTest]
    public IEnumerator PlayerAnimationTest()
    {
        // Wait for one frame to ensure all animations are initialized
        yield return null;

        // Check if the player's idle animation is playing by default
        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"), "Player is not in Idle state by default");

        playerAnimator.SetFloat("Speed", 1.0f);

        // Wait for a few frames to allow the animation to transition
        yield return new WaitForSeconds(0.5f);

        // Check if the player's movement animation is playing
        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunningUp"), "Player is not in Run state after moving");

        playerAnimator.SetFloat("Speed", 0.0f);

        // Wait for a few frames to allow the animation to transition
        yield return new WaitForSeconds(0.5f);

        // Check if the player's idle animation is playing again
        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"), "Player did not return to Idle state after stopping");

        playerAnimator.SetFloat("Speed", 1.0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunningDown"), "Player is not in Run state after moving");

        playerAnimator.SetFloat("Speed", 0.0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"), "Player did not return to Idle state after stopping");

        playerAnimator.SetFloat("Speed", 1.0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunningRight"), "Player is not in Run state after moving");

        playerAnimator.SetFloat("Speed", 0.0f);

        yield return new WaitForSeconds(0.5f);

        Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("Idle"), "Player did not return to Idle state after stopping");

        playerAnimator.SetFloat("Speed", 1.0f);

        yield return new WaitForSeconds(0.5f);

         Assert.IsTrue(playerAnimator.GetCurrentAnimatorStateInfo(0).IsName("RunningLeft"), "Player is not in Run state after moving");


    }
}
using System.Runtime.Versioning;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;

public class CharacterDirectionTest
{
    private GameObject playerPrefab;
    private CharacterController characterController;

    [SetUp]
    public void Setup()
    {
        // Load the scene containing the player
        SceneManager.LoadScene("SampleScene");

       playerPrefab = Resources.Load<GameObject>("Player");
       //characterController = playerPrefab.GetComponent<PlayerController>();
       Assert.IsNotNull(characterController, "CharacterController component not found on the player object");
    }

    [UnityTest]
    public IEnumerator PlayerMovesInCorrectDirection()
    {
        // Simulate player input to move the player in different directions
        yield return MovePlayer(Vector3.forward);
        yield return MovePlayer(Vector3.right);
        yield return MovePlayer(Vector3.back);
        yield return MovePlayer(Vector3.left);
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        // Simulate player input to move the player in the specified direction
        Vector3 initialPosition = playerPrefab.transform.position;
        characterController.Move(direction * Time.deltaTime);

        // Wait for one frame to allow the player to move
        yield return null;

        // Check if the player moved in the correct direction
        Vector3 finalPosition = playerPrefab.transform.position;
        Vector3 expectedPosition = initialPosition + direction;
        Assert.AreEqual(expectedPosition, finalPosition, "Player did not move in the correct direction");
    }
}
//using System.Collections;
//using NUnit.Framework;
//using UnityEngine;
//using UnityEngine.SceneManagement;
//using UnityEngine.TestTools;

//public class WeaponSoundTest
//{
//    private GameObject weaponGameObject;
//    public Weapon weaponScript;

//    [SetUp]
//    public void Setup()
//    {
//        // Load the scene asynchronously
//        SceneManager.LoadSceneAsync("TestingScene", LoadSceneMode.Single).completed += SceneLoaded;
//    }

//    // Callback method to handle scene loaded event
//    private void SceneLoaded(AsyncOperation asyncOperation)
//    {
//        // Find the weapon GameObject after scene is loaded
//        weaponGameObject = GameObject.FindGameObjectWithTag("Weapon");
//        weaponScript = weaponGameObject.GetComponent<Weapon>();
//    }

//    [UnityTest]
//    public IEnumerator WeapSoundStressTest()
//    {
//        yield return new WaitUntil(() => weaponScript != null); // Wait until weapon script is assigned

//        AudioSource audioSource = weaponScript.audioSource;
//        Assert.IsNotNull(audioSource, "Audio Source is null.");

//        // Increase firing rate for stress testing
//        float initialFireRate = weaponScript.fireRate;
//        weaponScript.fireRate = 0.01f; // Set a very low fire rate for rapid firing

//        float originalVolume = audioSource.volume;
//        audioSource.volume = 0; // Mute the audio source temporarily for testing

//        // Start firing rapidly to stress the audio system
//        weaponScript.StartFiring();
//        yield return new WaitForSeconds(2.0f); // Fire for 2 seconds

//        Assert.IsTrue(audioSource.isPlaying, "Audio Source is not playing.");

//        // Stop firing
//        weaponScript.StopFiring();

//        // Reset volume and fire rate
//        audioSource.volume = originalVolume;
//        weaponScript.fireRate = initialFireRate;
//    }
//}

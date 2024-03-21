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
//        // load dummy scene
//        SceneManager.LoadScene("TestingScene");
//    }
//    [UnityTest]
//    public IEnumerator WeapSoundTest()
//    {
//        AudioSource audioSource = weaponScript.audioSource;
//        Assert.IsNotNull(audioSource, "Audio Source is null.");

//        float originalVolume = audioSource.volume;
//        audioSource.volume = 0; // Mute the audio source temporarily for testing

//        weaponScript.StartFiring(); // Start firing to trigger the sound
//        yield return new WaitForSeconds(0.1f); // Wait for the sound to play

//        Assert.IsTrue(audioSource.isPlaying, "Audio Source is not playing.");

//        weaponScript.StopFiring(); // Stop firing

//        audioSource.volume = originalVolume; // Reset the volume
//    }
//}

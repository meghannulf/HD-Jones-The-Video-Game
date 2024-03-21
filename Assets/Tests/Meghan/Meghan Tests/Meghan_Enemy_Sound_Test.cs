/*using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemySoundTest
{
    private GameObject enemyGameObject;
    private Enemy enemyScript;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("SampleScene"); // Load the SampleScene
        GameObject[] gameObjects = SceneManager.GetActiveScene().GetRootGameObjects();
        foreach (GameObject go in gameObjects)
        {
            if (go.CompareTag("Enemy"))
            {
                enemyGameObject = go;
                enemyScript = enemyGameObject.GetComponent<Enemy>();
                break;
            }
        }
    }

    [UnityTest]
    public IEnumerator EnemyNoiseTest()
    {
        AudioSource enemyNoise = enemyScript.enemyNoise;
        Assert.IsNotNull(enemyNoise, "Enemy Noise Audio Source is null.");

        float originalVolume = enemyNoise.volume;
        enemyNoise.volume = 0; // Mute the audio source temporarily for testing

        // Simulate collision with a bullet
        GameObject bullet = new GameObject();
        bullet.tag = "Bullet";
        enemyScript.OnCollisionEnter2D(bullet.AddComponent<Collision2D>()); // Trigger the collision event to play the sound
        yield return new WaitForSeconds(0.1f); // Wait for the sound to play

        Assert.IsTrue(enemyNoise.isPlaying, "Enemy Noise Audio Source is not playing.");

        enemyNoise.volume = originalVolume; // Reset the volume
        GameObject.Destroy(bullet);
    }

    [UnityTest]
    public IEnumerator ChampionSoundTest()
    {
        AudioSource championSound = enemyScript.championSound;
        Assert.IsNotNull(championSound, "Champion Sound Audio Source is null.");

        float originalVolume = championSound.volume;
        championSound.volume = 0; // Mute the audio source temporarily for testing

        // Set totalEnemies to 1 for testing the champion sound trigger
        Enemy.totalEnemies = 1;

        // Destroy the enemy to trigger champion sound
        GameObject.Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.1f); // Wait for the sound to play

        Assert.IsTrue(championSound.isPlaying, "Champion Sound Audio Source is not playing.");

        championSound.volume = originalVolume; // Reset the volume
    }
}*/

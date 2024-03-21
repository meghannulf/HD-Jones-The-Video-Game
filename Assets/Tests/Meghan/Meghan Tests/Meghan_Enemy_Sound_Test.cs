
using System.Collections;
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
        SceneManager.LoadScene("SampleScene");  #Load the SampleScene
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
    public IEnumerator EnemyNoiseStressTest()
    {
        AudioSource enemyNoise = enemyScript.enemyNoise;
        Assert.IsNotNull(enemyNoise, "Enemy Noise Audio Source is null.");

        float originalVolume = enemyNoise.volume;
        enemyNoise.volume = 0;  //Mute the audio source temporarily for testing

        const int numCollisions = 1000;  //Define the number of collisions to simulate

        //Instantiate a bullet prefab for collision
        GameObject bulletPrefab = new GameObject();
        bulletPrefab.tag = "Bullet";

        for (int i = 0; i < numCollisions; i++)
        {
            //Instantiate bullet at random position and direction
            Vector3 randomPosition = new Vector3(Random.Range(-10f, 10f), Random.Range(-10f, 10f), 0f);
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
            GameObject bullet = GameObject.Instantiate(bulletPrefab, randomPosition, Quaternion.identity);
            bullet.GetComponent<Rigidbody2D>().velocity = randomDirection * 10f;

            yield return new WaitForSeconds(0.1f);  //Wait for a short time between collisions
        }

        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

        Assert.IsTrue(enemyNoise.isPlaying, "Enemy Noise Audio Source is not playing.");

        enemyNoise.volume = originalVolume;  //Reset the volume

         //Clean up instantiated objects
        GameObject.Destroy(bulletPrefab);
    }

    [UnityTest]
    public IEnumerator ChampionSoundBoundaryTest()
    {
        AudioSource championSound = enemyScript.championSound;
        Assert.IsNotNull(championSound, "Champion Sound Audio Source is null.");

        float originalVolume = championSound.volume;
        championSound.volume = 0;  //Mute the audio source temporarily for testing

        //Set totalEnemies to 0 and destroy all enemies
        Enemy.totalEnemies = 0;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            GameObject.Destroy(enemy);
        }
        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

        Assert.IsFalse(championSound.isPlaying, "Champion Sound should not play when there are no enemies.");

        //Set totalEnemies to 1 for testing the champion sound trigger
        Enemy.totalEnemies = 1;

        //Destroy the enemy to trigger champion sound
        GameObject.Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

        Assert.IsTrue(championSound.isPlaying, "Champion Sound should play when there is exactly one enemy.");

        //Create multiple enemies
        GameObject enemy2 = new GameObject();
        enemy2.tag = "Enemy";
        Enemy.totalEnemies = 2;

        //Destroy one enemy to trigger champion sound
        GameObject.Destroy(enemyGameObject);
        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

        Assert.IsTrue(championSound.isPlaying, "Champion Sound should play when there are multiple enemies.");

        championSound.volume = originalVolume;  //Reset the volume
    }
}


using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class EnemySoundTest
{
    //private GameObject enemyGameObject;
// private Enemy enemyScript;

    [SetUp]
    public void Setup()
    {
        SceneManager.LoadScene("SampleScene");  //Load the SampleScene
        //GameObject enemyObj = new GameObject("Treevle", typeof(BoxCollider2D), typeof(SpriteRenderer));
        //GameObject.Instantiate(enemyObj);
    }

    [UnityTest]
    public IEnumerator EnemyNoiseBoundaryTest()
    {
        GameObject gameObject = new GameObject();
        gameObject.AddComponent<Enemy>();
        gameObject.transform.position = new Vector3(10f, 10f, 10f);
        Vector3 enemyPos = gameObject.transform.position;

        GameObject bullObject = new GameObject();
        bullObject.AddComponent<Bullet>();
        

        // Ensure both objects have colliders
        gameObject.AddComponent<PolygonCollider2D>();
        bullObject.AddComponent<CircleCollider2D>();

        // Ensure both objects have rigidbodies
        gameObject.AddComponent<Rigidbody2D>();
        bullObject.AddComponent<Rigidbody2D>();
        bullObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;

        // Set the bullet's initial position and velocity to move towards the enemy
        bullObject.GetComponent<Rigidbody2D>().velocity = (enemyPos - bullObject.transform.position).normalized;

        AudioSource enemyAudio = new AudioSource();
        enemyAudio.GetComponent<Enemy>().GetComponent<AudioSource>();
        //enemyAudio.GetComponent<AudioSource>();
        
        yield return new WaitForSeconds(10);


        Assert.True(enemyAudio.isPlaying);
    }
}

    //[UnityTest]
    //    public IEnumerator ChampionSoundBoundaryTest()
    //    {
    //        AudioSource championSound = enemyScript.championSound;
    //        Assert.IsNotNull(championSound, "Champion Sound Audio Source is null.");

    //        float originalVolume = championSound.volume;
    //        championSound.volume = 0;  //Mute the audio source temporarily for testing

    //        //Set totalEnemies to 0 and destroy all enemies
    //        Enemy.totalEnemies = 0;
    //        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
    //        foreach (GameObject enemy in enemies)
    //        {
    //            GameObject.Destroy(enemy);
    //        }
    //        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

    //        Assert.IsFalse(championSound.isPlaying, "Champion Sound should not play when there are no enemies.");

    //        //Set totalEnemies to 1 for testing the champion sound trigger
    //        Enemy.totalEnemies = 1;

    //        //Destroy the enemy to trigger champion sound
    //        GameObject.Destroy(enemyGameObject);
    //        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

    //        Assert.IsTrue(championSound.isPlaying, "Champion Sound should play when there is exactly one enemy.");

    //        //Create multiple enemies
    //        GameObject enemy2 = new GameObject();
    //        enemy2.tag = "Enemy";
    //        Enemy.totalEnemies = 2;

    //        //Destroy one enemy to trigger champion sound
    //        GameObject.Destroy(enemyGameObject);
    //        yield return new WaitForSeconds(0.1f);  //Wait for the sound to play

    //        Assert.IsTrue(championSound.isPlaying, "Champion Sound should play when there are multiple enemies.");

    //        championSound.volume = originalVolume;  //Reset the volume
    //    }
    //}

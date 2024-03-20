using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;


public class ScenetoLevel1
{
    [SetUp]
    public void Setup() {
        SceneManager.LoadScene("SampleScene");
    }

    [UnityTest]
    public IEnumerator SampletoLevel1() {
        Scene currentScene = SceneManager.GetActiveScene();

        Assert.AreEqual("SampleScene", currentScene.name);

        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Level1");

        while (!asyncLoad.isDone) {
            yield return null;
        }

        currentScene = SceneManager.GetActiveScene();

        Assert.AreEqual("Level1", currentScene.name);
    }

}


using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using System.Collections;


public class Level1toSampleScene
{
    [SetUp]
    public void Setup() {
        SceneManager.LoadScene("Level1");
    }

    [UnityTest]
    public IEnumerator Level1toSample() {
        Scene currentScene = SceneManager.GetActiveScene();

        Assert.AreEqual("Level1", currentScene.name);

        yield return null;

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        while (!asyncLoad.isDone) {
            yield return null;
        }

        currentScene = SceneManager.GetActiveScene();

        Assert.AreEqual("SampleScene", currentScene.name);
    }

}


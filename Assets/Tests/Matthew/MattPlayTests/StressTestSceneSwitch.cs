using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using UnityEngine.SceneManagement;
using System.Diagnostics;

public class StressTestSceneSwitch
{
    public string[] sceneNames = {"SampleScene", "Level1"};
    public int iterations = 10;
    public int maxLoadingTimeMillisecs = 5000;
    [UnityTest]
    public IEnumerator StressTestSceneSwitchWithEnumeratorPasses()
    {
        foreach (string sceneName in sceneNames) {
            for (int i = 0; i < iterations; i++) {
                Stopwatch stopwatch = Stopwatch.StartNew();
                AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);
                yield return asyncLoad;
                stopwatch.Stop();
                Assert.IsTrue(asyncLoad.isDone && asyncLoad.progress >= 0.9f, $"Scene '{sceneName}' failed to load");
                Assert.LessOrEqual(stopwatch.ElapsedMilliseconds, maxLoadingTimeMillisecs,
                    $"Scene '{sceneName}' took too long to load (expected <= {maxLoadingTimeMillisecs} milliseconds, actual: {stopwatch.ElapsedMilliseconds} milliseconds)");
            }
        }
    }
}

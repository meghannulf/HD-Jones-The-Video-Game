using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] spawnObjects;
    public Transform[] spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Random.Range(2, 4); i++)
        {
            Instantiate(spawnObjects[Random.Range(0, spawnObjects.Length)], spawnLocations[Random.Range(0, spawnLocations.Length)]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

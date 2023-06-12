using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] collectiables;
    public int xRange = 8;
    public int zRange = 15;
    public float startDelay = 1.9f;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomCollectiable", startDelay, spawnInterval);
    }

    // Update is called once   frame
    void Update()
    {
    }
    
    void SpawnRandomCollectiable()
    {
        int collectiablesIndex = Random.Range(0, collectiables.Length);
        Vector3 spawnPos = new Vector3(Random.Range(-xRange, xRange), 4, Random.Range(-zRange, zRange));
        Instantiate(collectiables[collectiablesIndex], spawnPos, collectiables[collectiablesIndex].transform.rotation);
    }
}

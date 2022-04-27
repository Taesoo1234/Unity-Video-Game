using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPlatform", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnRandomPlatform()
    {
        int PlatformIndex = Random.Range(0, PlatformPrefabs.Length);
        Instantiate(PlatformPrefabs[PlatformIndex], new Vector3(30, 3, 0), PlatformPrefabs[PlatformIndex].transform.rotation);
    }
}

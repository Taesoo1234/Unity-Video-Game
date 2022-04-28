using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public float startDelay = 2;
    public float spawnInterval = 1.5f;
    public float MinVerticalSpawnRange = 2;
    public float MaxVerticalSpawnRange = 6;
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
        Instantiate(PlatformPrefabs[PlatformIndex], GenerateSpawnPosition(), PlatformPrefabs[PlatformIndex].transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosY = Random.Range(MinVerticalSpawnRange, MaxVerticalSpawnRange);
        Vector3 randomPos = new Vector3(30, spawnPosY, 0);
        return randomPos;
    }
}

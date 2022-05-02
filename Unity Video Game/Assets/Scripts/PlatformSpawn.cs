using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawn : MonoBehaviour
{
    // the powerup manager also uses the same script despite being intended to spawn powerups, 
    // as the script's intended behavior is identical between the two spawnmanagers

    // the object the spawnmanager will use to create clones of
    public GameObject[] PlatformPrefabs;

    // the delay at the start of the game
    public float startDelay = 2;

    // the delay between platform spawns
    public float spawnInterval = 1.5f;

    // the minimum and maximum height that the platforms can spawn at
    public float MinVerticalSpawnRange = 2;
    public float MaxVerticalSpawnRange = 6;
    // Start is called before the first frame update
    void Start()
    {
        // repeat the 'SpawnRandomPlatform' part of the code, while having a delay(startDelay)
        // and an interval between repeats(spawnInterval)
        InvokeRepeating("SpawnRandomPlatform", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }


    void SpawnRandomPlatform()
    {
        // create prefabs of the platforms using the integer 'platformIndex', while using 'GenerateSpawnPosition'
        // to determine the spawning position
        int platformIndex = Random.Range(0, PlatformPrefabs.Length);
        Instantiate(PlatformPrefabs[platformIndex], GenerateSpawnPosition(), PlatformPrefabs[platformIndex].transform.rotation);
    }

    // generate a vector3 position to replace (GenerateSpawnPosition) in line 30
    private Vector3 GenerateSpawnPosition()
    {
        // create a float called spawnposY to determine
        // the height of a platform by using a random range between the 
        // maximum and minimum public variables in line 10 and 11
        float spawnPosY = Random.Range(MinVerticalSpawnRange, MaxVerticalSpawnRange);

        // create a vector3 postion by accounting for spawnPosy, determines its spawn position
        Vector3 randomPos = new Vector3(30, spawnPosY, 0);
        return randomPos;
    }
}

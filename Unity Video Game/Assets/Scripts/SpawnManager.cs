using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the powerupmanager also uses the same script despite this scrip being intended to spawn enemys, 
// as the powerupmanager's intended behavior is identical between with the spawnmanager

public class SpawnManager : MonoBehaviour
{
    // the floats that determine the minimum and maximum height that the objects can spawn
    public float MinVerticalSpawnRange = 0;
    public float MaxVerticalSpawnRange = 10;

    // the prefabs that the spawnmanager uses, called 'enemyPrefabs'
    public GameObject[] enemyPrefabs;

    // the floats that determine the minimum and maximum delay between spawns
    public float MinSpawnInterval = 2;
    public float MaxSpawnInterval = 4;

    // the delay at the start before spawns
    public float spawnDelay= 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        // repeat the process 'SpawnRandomEnemy' while accounting for a randomly generated spawn delay
        // and the spawn interval
        InvokeRepeating("SpawnRandomEnemy", spawnDelay, GenerateSpawnDelay());
    }

    
    private Vector3 GenerateSpawnPosition ()
    {
        // create a float called spawnposY to determine
        // the height of the enemy spawn by using a random range between the 
        // maximum and minimum public variables in line 8 and 9
        float spawnPosY = Random.Range(MinVerticalSpawnRange, MaxVerticalSpawnRange);
        Vector3 randomPos = new Vector3(17, spawnPosY, 0);
        return randomPos;
    }

    private float GenerateSpawnDelay()
    {
        // creates a random value that determines the delay between enemy spawns
        float SpawnDelay = Random.Range(MinSpawnInterval, MaxSpawnInterval);
        return SpawnDelay;
    }

    void SpawnRandomEnemy()
    {
        // create prefabs of the enemy using the integer 'enemyIndex', while using 'GenerateSpawnPosition'
        // to determine the spawning position
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float MinVerticalSpawnRange = 0;
    public float MaxVerticalSpawnRange = 10;
    public GameObject[] enemyPrefabs;
    public float startDelay = 2;
    public float spawnInterval = 3.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
    }

    private Vector3 GenerateSpawnPosition ()
    {
        float spawnPosY = Random.Range(MinVerticalSpawnRange, MaxVerticalSpawnRange);
        Vector3 randomPos = new Vector3(17, spawnPosY, 0);
        return randomPos;
    }
    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIndex], GenerateSpawnPosition(), enemyPrefabs[enemyIndex].transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float MinVerticalSpawnRange = 0;
    public float MaxVerticalSpawnRange = 10;
    public float MinHorizontalSpawnRange = 0;
    public float MaxHorizontalSpawnRange = 10;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition ()
    {
        float spawnPosX = Random.Range(MinHorizontalSpawnRange, MaxHorizontalSpawnRange);
        float spawnPosY = Random.Range(MinVerticalSpawnRange, MaxVerticalSpawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, spawnPosY, 0);
        return randomPos;
    }
    // Update is called once per frame
    void Update()
    {
       
    }
}

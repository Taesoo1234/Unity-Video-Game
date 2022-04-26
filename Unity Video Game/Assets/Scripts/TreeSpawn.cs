using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    public GameObject[] TreePrefabs;
    public float startDelay = 1;
    public float spawnInterval = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomTree", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    void SpawnRandomTree()
    {
        int TreeIndex = Random.Range(0, TreePrefabs.Length);
        Instantiate(TreePrefabs[TreeIndex], new Vector3(30, 3, 2), TreePrefabs[TreeIndex].transform.rotation);
    }
}

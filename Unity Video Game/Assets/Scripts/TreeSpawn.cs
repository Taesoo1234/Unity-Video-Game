using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeSpawn : MonoBehaviour
{
    // the prefabs that the spawnmanager uses, called 'TreePrefabs'
    public GameObject[] TreePrefabs;

    // the floats that determine the delay between spawns
    public float startDelay = 2;

    // the interval between spawns
    public float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        // repeat the process 'SpawnRandomEnemy' while accounting for a  delay(startDelay)
        // and an interval(spawnInterval)
        InvokeRepeating("SpawnRandomTree", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    
    void SpawnRandomTree()
    {
        // create prefabs of the Trees using the integer 'treeIndex', placing them at the
        // specified Vector3
        int treeIndex = Random.Range(0, TreePrefabs.Length);
        Instantiate(TreePrefabs[treeIndex], new Vector3(30, 3, 2), TreePrefabs[treeIndex].transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Enemy gets its own script because its rotation is different compared to other objects
    void Update()
    {
        // move left
        transform.Translate(Vector3.forward * speed);
    }
}

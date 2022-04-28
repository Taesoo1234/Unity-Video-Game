using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public float speed;
    public float platformspeed;
    public bool isOnPlatform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    // Enemy gets its own script because its rotation is different compared to other objects
    void Update()
    {
        // move left
        if (isOnPlatform = true)
        {
            transform.Translate(Vector3.forward * platformspeed);
        }
        else
        {
            transform.Translate(Vector3.forward * speed);
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnPlatform = true;
        }
    }
    
}

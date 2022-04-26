using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    public float Speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the enemy move right
        transform.Translate(Vector3.left * Speed) ;

        // deletes anything that goes too far left
        if (transform.position.x < -100)
        {
            Destroy(gameObject);
        }
    }
}


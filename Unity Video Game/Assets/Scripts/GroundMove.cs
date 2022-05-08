using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMove : MonoBehaviour
{
    // the speed of the object
    public float speed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the enemy move right, velcoity is determined by the speed variable
        transform.Translate(Vector3.left * speed) ;
    }
}


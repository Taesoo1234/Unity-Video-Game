using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is a general script for objects that do not have rotations and allows them to move left
// certain objects have different rotations, and require different scripts
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
        // makes the gameObject move right, velcoity is determined by the speed variable
        transform.Translate(Vector3.left * speed) ;
    }
}


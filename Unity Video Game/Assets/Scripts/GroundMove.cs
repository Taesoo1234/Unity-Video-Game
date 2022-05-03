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

        // checks if the object has moved very far to the left, specifically past x = 15
        if (transform.position.x < -15 && gameObject.CompareTag("Tree"))
        {
            // if yes, destroy the object
            Destroy(gameObject);
        }
    }
}


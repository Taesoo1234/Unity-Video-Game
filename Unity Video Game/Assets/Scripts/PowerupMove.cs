using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupMove : MonoBehaviour
{
    // powerup gets its own movescript due to having a different rotation compared to other objects

    // the speed of the object
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the powerup move right, velcoity is determined by the speed variable
        transform.Translate(Vector3.right * speed);

        // checks if the object has moved very far to the left, specifically past x = -15
        if (transform.position.x < -15)
        {
            // if yes, destroy the object
            Destroy(gameObject);
        }
    }
}

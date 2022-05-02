using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    // platforms have a different rotation compared to other objects, so they require their own script

    // the speed of the object
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the platform move left towards the left (accounting for rotation)
        transform.Translate(Vector3.right * speed);

        // checks if the object has gone left past x = -25
        if (transform.position.x < -25)
        {
            //if yes, destroy it
            Destroy(gameObject);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // makes the platform move left (platform rotation is 180)
        transform.Translate(Vector3.right * Speed);

        // deletes anything that goes too far left
        if (transform.position.x < -25)
        {
            Destroy(gameObject);
        }
    }
}

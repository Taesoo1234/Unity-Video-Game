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
        transform.Translate(Vector3.forward * Speed);
    }
   
    void OnCollisionEnter(Collider Bullet)
    {
        Destroy(this.gameObject);
    }
}


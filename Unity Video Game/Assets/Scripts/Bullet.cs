using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // the float speed is the speed at which the bullet travels, and being
    // public allows it to be changed on the fly in the editor
    public float speed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // destroys the bullet after going far right enough
        if (transform.position.x > 16)
        {
            Destroy(gameObject);
        }
    }

    // destroy anything this touches, and delete itself as well
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Target"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

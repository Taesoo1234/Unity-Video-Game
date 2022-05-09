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
        // makes the bullet go right (up is after rotating the bullet)
        // The velocity is determined by the time and the speed
        transform.Translate(Vector3.up * Time.deltaTime * speed);

        // destroys the bullet after the position is transformed enough that it goes past x = 16 (aka far right)
        if (transform.position.x > 16)
        {
            Destroy(gameObject);
        }
    }

    // checks for collisions
    void OnTriggerEnter(Collider other)
    {
        // checks upon collision if the target has a tag called 'target'
        if (other.CompareTag("Target"))
        {
            // if yes, destroys the target and destroys the bullet
            // sends a message to the parent object called "IncreaseScore"
            Destroy(gameObject);
            Destroy(other.gameObject);
            gameObject.SendMessageUpwards("IncreaseScore");
        }

        else
        {
            // if no, destroy the bullet and do nothing else
            Destroy(gameObject);
        }
    }
}

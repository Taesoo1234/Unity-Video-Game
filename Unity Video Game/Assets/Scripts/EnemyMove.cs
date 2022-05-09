using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Enemy gets its own script because its rotation is different compared to other objects
// Enemy and target both share the same script as they have the same intended behavior
public class EnemyMove : MonoBehaviour
{
    // the speed of the object on the ground
    public float speed;

    // the speed of the object if the script detects the enemy
    // on a platform
    public float platformspeed;

    // a bool that is true or false depending on if the
    // enemy is on a platform
    public bool isOnPlatform;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the enemy is on the platform
        if (isOnPlatform = true)
        {
            // if true, match the speed of the platform so that it doesnt fall off
            transform.Translate(Vector3.forward * platformspeed);
        }

        else
        {
            // otherwise on the ground, travel at a slower speed on the ground
            transform.Translate(Vector3.forward * speed);
        }


        // checks if the object has moved very far to the left, specifically past x = -15
        if (transform.position.x < -15)
        {
            // if yes, destroy the object
            Destroy(gameObject);
        }

    }

    //checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // checks if the terrain it is touching is a platform by checking for
        // the 'Platform' tag
        if (collision.gameObject.CompareTag("Platform"))
        {
            // if true, the bool becomes true, changing the speed of the enemy
            isOnPlatform = true;
        }
    }
    
}

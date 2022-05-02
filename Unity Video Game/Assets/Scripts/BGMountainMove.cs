using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMountainMove : MonoBehaviour
{   // startPos is the value for the starting position of the mountain,
    // and is where the mountain will be moved back to after going past the
    // player to give the looping effect
    // the float speed is the speed of the mountain, and making it public
    // allows it to be changed on the fly in the editor
    private Vector3 startPos;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        // this logs the starting position of the mountain into the variable,
        // and will be referenced to where the mountain will be teleported into
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // this makes the mountain move left towards and past the player,
        // and is multiplied by the time and speed
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        // this checks to see if the mountain has moved far enough left,
        // specifically 100 units to the left
        if (transform.position.x < startPos.x - 100)
        {
            // if it is true, then the mountain will be moved back to the starting position
            transform.position = startPos;
        }
    }
}

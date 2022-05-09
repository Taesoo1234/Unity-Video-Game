using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // although the script is intended for the camera,
    // the score text uses it as well as it needs to track
    // the player's position to stay in frame
    public float xoffset = 0;
    public float yoffset = 2;
    public float zoffset = -7;

    // the gameobject is the object that the camera tracks, called player as it is intended to track the player
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the camera position to match the player position, then adjust the vector3 position by the offset values
        transform.position = player.transform.position + new Vector3(xoffset, yoffset, zoffset);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // the gameobject is the object that the camera tracks, called player as it is intended to track the player
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //update the camera position to match the player position, then adjust the vector3 position by 2 up and 7 back
        transform.position = player.transform.position + new Vector3(0, 2, -7);
    }
}

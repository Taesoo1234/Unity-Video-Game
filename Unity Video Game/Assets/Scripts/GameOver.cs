using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // checks if the gameobject 'Player' has been deleted
        if (GameObject.Find("Player") == null)
        {
            // if  yes, then move to the new vector3 position
            //(to be visible to the player
            transform.position = new Vector3(5, 6, 1);
        }
    }
}

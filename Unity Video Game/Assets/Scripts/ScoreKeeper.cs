using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    public float score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (score > 15)
        {
            Debug.Log("You Win!");
        }
    }
    
    void OnTriggerEnter(Collider Bullet)
    {
        if(Bullet.transform.tag == "Target")
        {
            score = score + 1;
        }

    }
}

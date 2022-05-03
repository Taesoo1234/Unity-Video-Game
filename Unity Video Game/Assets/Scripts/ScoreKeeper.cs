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

    }


    public void IncreaseScore()
    {
        score = score + 1;
        Debug.Log(score);
    }   
}

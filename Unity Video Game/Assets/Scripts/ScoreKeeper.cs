using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{
    // the float that is the current score of the player
    public float score = 0;
    public Text CurrentScore;
    // Start is called before the first frame update
    void Start()
    {
        CurrentScore.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CurrentScore.text = "Score:" + score;
    }

    // when recieveing the message IncreaseScore
    public void IncreaseScore()
    {
        score = score + 1;
        Debug.Log(score);
    }   
}

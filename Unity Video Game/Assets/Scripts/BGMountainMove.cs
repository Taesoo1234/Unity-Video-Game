using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMountainMove : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;
    public float speed = 20;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (transform.position.x < startPos.x - 100)
        {
            transform.position = startPos;
        }
    }
}

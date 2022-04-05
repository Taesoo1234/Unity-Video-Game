using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        // Track the player and get their component
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // move toward the player
        //enemyRb.AddForce((player.transform.position - transform.position).normalized * speed);
        Vector3 lookDirection = (player.transform.position - transform.position).normalized * speed;
        enemyRb.AddForce(lookDirection * speed);
    }
}

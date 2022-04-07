using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody playerRb;
    public float jumpForce;
    public float gravityModifier;
    public float moveSpeed;
    public float forwardInput;
    public bool isOnGround;
    public GameObject projectilePrefab;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //move left or right when pressing left arrow or right arrow
        forwardInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * forwardInput * moveSpeed);

        // code to allow the character to jump when pressing space, as well as preventing double jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    //checks if the character is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
    
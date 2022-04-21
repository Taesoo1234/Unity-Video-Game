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
    public bool gameOver = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        //makes the player constantly move right
        transform.Translate(Vector3.forward * moveSpeed);
        

        // code to allow the character to jump when pressing space, as well as preventing double jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        // code to make the player shoot when pressing Z
        if (Input.GetKeyDown(KeyCode.Z))
        {

            Instantiate(projectilePrefab, transform.position + (Vector3.up * 0.45f) + (Vector3.forward * 1.15f), projectilePrefab.transform.rotation);
        }
    }

    //checks if the character is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
        //checks if the character is touching an enemy, and kills the player if it is
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            Destroy(gameObject);
        }

    }
}
    
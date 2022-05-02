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
    public bool hasPowerup = false;
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameOver = false;
        hasPowerup = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        

        // code to allow the character to jump when pressing space, as well as preventing double jumps
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
        // code to make the player shoot when pressing Z
        if (Input.GetKeyDown(KeyCode.Z))
        {

            Instantiate(projectilePrefab, transform.position + (Vector3.up * 0.45f) + (Vector3.right * 1.15f), projectilePrefab.transform.rotation);
        }
        // code that makes the player move offscreen after touching an enemy
        if (gameOver = true)
        {
        
        }

        // checks if the player has touched a powerup, and grants them increased jump height if they have
        if (hasPowerup = true)
        {
            jumpForce = 750;
        }
        else
        {
            jumpForce = 600;
        }
    }

    //checks if the character is on the ground
    private void OnCollisionEnter(Collision collision)
    {
        // checks if the character is on the ground to let them jump
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // checks if the character is on a platform to let them jump
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }
        //checks if the character is touching an enemy, and kills the player if it is
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }

        //checks if the player is touching a target, and kills the player if they are
        else if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }

        if (collision.gameObject.CompareTag("Powerup"))
        {
            hasPowerup = true;
            //Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerup = false;
    }
}
    
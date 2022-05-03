using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    // the rigidbody of the player that can be used for physics
    private Rigidbody playerRb;

    // the jumping variables, jumpForce controls how high the jump is and
    // the gravityModifier controls the falling speed
    public float jumpForce;
    public float gravityModifier;

    // a bool that is true/false depending on if the player is on the ground
    public bool isOnGround;

    // the gameobject that is used for the projectile when pressing the shoot button
    public GameObject projectilePrefab;
    
    // bools that check if the game is in a game-over state and if the player has a powerup
    public bool gameOver = false;
    public bool hasPowerup = false;
    void Start()
    {
        // creates a rigidbody component called playerRb
        playerRb = GetComponent<Rigidbody>();

        // the gravity is multiplied by the float 'gravity Modifier'
        Physics.gravity *= gravityModifier;

    }

    // Update is called once per frame
    void Update()
    {
        
        

        // checks if the space key is pressed, and if the isOnGround bool is true
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            // if both conditions are satisfied, make the player jump by adding force vertically
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // make isOnGround false as jumping makes the player no longer touch the ground
            isOnGround = false;
        }

        // checks if the player has pressed the shoot(z) button
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // if yes, then instantiate a prefab of the projectile with an offset of up .45, right 1.15.
            Instantiate(projectilePrefab, transform.position + (Vector3.up * 0.45f) + (Vector3.right * 1.15f), projectilePrefab.transform.rotation);
        }
        // code that makes the player move offscreen after touching an enemy
        if (gameOver = true)
        {
        
        }
    }

    //checks for collisions
    private void OnCollisionEnter(Collision collision)
    {
        // if the collision is with an object with tag 'ground',
        // make the isOnGround bool true
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        // if the collision is with an object with tag 'Ground'
        // and hasPowerup = True;
        // make the isOnGround bool true
        // increase jumpForce to 750
        if (collision.gameObject.CompareTag("Ground") && hasPowerup)
        {
            isOnGround = true;
            jumpForce = 750;
        }
        // if the collision is with an object with tag 'platform',
        // make the isOnGround bool true
        if (collision.gameObject.CompareTag("Platform"))
        {
            isOnGround = true;
        }

        // if the collision is with an object with tag 'platform'
        // and hasPowerup = True;
        // make the isOnGround bool true
        // increase jumpForce to 750
        if (collision.gameObject.CompareTag("Platform") && hasPowerup)
        {
            isOnGround = true;
            jumpForce = 750;
        }

        // if the collision is with an object with tag 'Enemy'
        // makes the gameOver bool true
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }

        // if the collision is with an object with tag 'Target'
        // makes the gameOver bool true
        else if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Game Over");
            gameOver = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the collision is with an object with tag 'Target'
        // makes the hasPowerup bool true
        // destroys the powerup gameObject
        // starts the coroutine to countdown the duration of the powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        //wait 5 seconds
        yield return new WaitForSeconds(5);

        // make the hasPowerup bool false
        hasPowerup = false;

        jumpForce = 600;
    }
}
    
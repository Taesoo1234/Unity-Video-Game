using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
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

    //An asset that shows when the player has a powerup
    public GameObject powerupIndicator;

    // Start is called before the first frame update
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
        // checks if the space key is pressed, and if the isOnGround bool is true and
        // if the player is not in a gameover state
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
        {
            // if both conditions are satisfied, make the player jump by adding force vertically
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            // make isOnGround false as jumping makes the player no longer touch the ground
            isOnGround = false;
        }

        // checks if the player has pressed the shoot(z) button and is not in a gameover state
        if (Input.GetKeyDown(KeyCode.Z) && !gameOver)
        {
            // if yes, then instantiate a prefab of the projectile with an offset of up .45, right 1.15.
            // and make the object a child of the object 'scorekeeper'
            GameObject go = Instantiate(projectilePrefab, transform.position + (Vector3.up * 0.45f) + (Vector3.right * 1.15f), projectilePrefab.transform.rotation) as GameObject;
            go.transform.parent = GameObject.Find("Scorekeeper").transform;
        }

        // makes the powerup indicator continously go behind the player
        powerupIndicator.transform.position = transform.position + new Vector3(-1, 1, 0);
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
            gameObject.SetActive(false);
        }

        // if the collision is with an object with tag 'Target'
        // makes the gameOver bool true
        else if (collision.gameObject.CompareTag("Target"))
        {
            Debug.Log("Game Over");
            gameOver = true;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // if the collision is with an object with tag 'Target'
        // makes the hasPowerup bool true
        // destroys the powerup gameObject
        // spawns the powerup indicator
        // starts the coroutine to countdown the duration of the powerup
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            Destroy(other.gameObject);
            powerupIndicator.gameObject.SetActive(true);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        // wait 5 seconds
        yield return new WaitForSeconds(5);

        // make the hasPowerup bool false
        hasPowerup = false;

        // removes the powerup indicator
        powerupIndicator.gameObject.SetActive(false);

        // returns the jump force to the normal amount
        jumpForce = 600;
    }
}
    
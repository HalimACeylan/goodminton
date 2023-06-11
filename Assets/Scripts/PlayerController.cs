using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for better and smooth movement change center of mass maybe ? 
public class PlayerController : MonoBehaviour
{
    public bool facePositiveZDirection = true;
    public float speed = 2f; // Movement speed of the player
    public static bool playerReset;
    private Rigidbody rb;
    public GameObject projectilePrefab;
    public float launchForce = 10f;
    public float projectileOffset = 2.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }


    void LaunchProjectile()
    {
        // Instantiate the projectile prefab
        Vector3 projectilePosition = transform.position + transform.up * projectileOffset;
        GameObject projectile = Instantiate(projectilePrefab, projectilePosition, new Quaternion(90f, 0f, 0f, 1));
    }

    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;
        // Get input for horizontal and vertical axes
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        //3D movement
        //Vector3 movement = new Vector3(horizontalInput, 0.0f, verticalInput);
        //rb.AddForce(movement * speed);
        //2D movement
        // Calculate new position based on input and move speed
        Vector3 newPosition = transform.position + new Vector3(horizontalInput * speed * Time.deltaTime, 0, verticalInput * speed * Time.deltaTime);
        // Update the object's position
        transform.position = newPosition;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //Launch a projectile from the player
            LaunchProjectile();
        }

        if (playerReset)
        {
            transform.position = new Vector3(5f, 1.5f, -17f);
            // Reset velocity to zero
            rb.velocity = Vector3.zero;
            // Reset angular velocity to zero
            rb.angularVelocity = Vector3.zero;
            playerReset = false;
        }
    }
    public void setPlayerReset()
    {
        playerReset = true;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        // Get reference to the Rigidbody component
        ballRigidbody = GetComponent<Rigidbody>();
        // Set initial velocity
        Vector3 initialVelocity = new Vector3(0f, 10f, 0f); // Upward velocity of 10 units per second
        ballRigidbody.velocity = initialVelocity;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get direction away from the player
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.y = 0.8f; // Remove the vertical component for a 2D-like parabolic trajectory
            // Normalize the direction
            direction.Normalize();
            // Apply force to the ball in the direction away from the player
            Vector3 force = direction * 7f; // Adjust the force based on desired strength
            ballRigidbody.AddForce(force, ForceMode.Impulse);


        }else if(collision.gameObject.CompareTag("Border")) {
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.y = 1f; // Remove the vertical component for a 2D-like parabolic trajectory
            // Normalize the direction
            direction.Normalize();

            // Apply force to the ball in the direction away from the player
            Vector3 force = direction * 3f; // Adjust the force based on desired strength
            ballRigidbody.AddForce(force, ForceMode.Impulse);

        }
        else{
            Vector3 collisionNormal = collision.contacts[0].normal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= 0.72)
        {
            transform.position = new Vector3(0f,10f,0f);
        }
    }
}

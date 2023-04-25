using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private float centerOfMass = 1f;
    public float rotationSpeed = 100f;
    // Start is called before the first frame update
    public global::System.Single CenterOfMass { get => centerOfMass; set => centerOfMass = value; }

    void Start()
    {
        // Get reference to the Rigidbody component
        ballRigidbody = GetComponent<Rigidbody>();
        // Set initial velocity
        Vector3 initialVelocity = new Vector3(0f, 10f, 0f); // Upward velocity of 10 units per second
        ballRigidbody.velocity = initialVelocity;
        ballRigidbody.centerOfMass = new Vector3(0, CenterOfMass, 0);

}
  


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Get direction away from the player
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.y = 6f; // Remove the vertical component for a 2D-like parabolic trajectory
            // Normalize the direction
            direction.Normalize();
            // Apply force to the ball in the direction away from the player
            Vector3 force = direction * 5.5f; // Adjust the force based on desired strength
            ballRigidbody.AddForce(force, ForceMode.Impulse);

        }else if(collision.gameObject.CompareTag("Border")) {
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            // Normalize the direction
            direction.Normalize();
            // Apply force to the ball in the direction away from the player
            Vector3 force = direction * 5f; // Adjust the force based on desired strength

            ballRigidbody.AddForce(force, ForceMode.Impulse);

        }
        else{
            Vector3 collisionNormal = collision.contacts[0].normal;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        if (transform.position.y <= 0.50)
        {
            ballRigidbody.velocity = Vector3.zero;
            ballRigidbody.angularVelocity = Vector3.zero;
            transform.position = new Vector3(Random.Range(4f,-7f),20f,Random.Range(-7f,-12f));
            //PlayerController.playerReset = true;
        }
    }
}

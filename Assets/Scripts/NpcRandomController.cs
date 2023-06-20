using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRandomController : MonoBehaviour
{
    public Transform ballTransform;  // Reference to the ball's transform
    public float movementSpeed = 16f; // Movement speed of the AI character
    public Quaternion initialRotation;
    public GameObject ballLocation;
    public Rigidbody aiRigidbody;
    private float timeRemaining = 0;
    private Color current;
    public float zMin = 7f;  // Minimum Z boundary
    public float zMax = 15f;    // Maximum Z boundary
    public float xMin = -8f;   // Minimum X boundary
    public float xMax = 11f;    // Maximum X boundary

    private void Start()
    {
        ballLocation = GameObject.FindWithTag("Ball");
        aiRigidbody = GetComponent<Rigidbody>();
        ballTransform = ballLocation.transform;
        current = GetComponent<Renderer>().material.color;

    }

    private void Update()
    {
        if (zMin < transform.position.z && transform.position.z < zMax && xMin < transform.position.x && transform.position.x < xMax)
        {
            // Check if the ball transform is available
            if (zMin < ballTransform.position.z && ballTransform.position.z < zMax && xMin < ballTransform.position.x && ballTransform.position.x < xMax)
            {
                // Calculate the direction from the AI character to the ball
                Vector3 direction = ballTransform.position - transform.position;
                direction.y = 0f;
                direction.z = direction.z + 4.0f;
                direction.Normalize();
                Transform head = this.transform.Find("a1").transform;
                // Move the AI character towards the ball
                Vector3 newPosition = transform.position + new Vector3(direction.x  * movementSpeed * Time.deltaTime, 0, direction.z * movementSpeed * Time.deltaTime);
                transform.position = newPosition;
            }


        }
        else
        {
            // If the AI character is outside the boundaries, set its position to a fixed location
            transform.rotation = initialRotation;
            aiRigidbody.velocity = Vector3.zero;
            // Reset angular velocity to zero
            aiRigidbody.angularVelocity = Vector3.zero;

            transform.position = new Vector3(0f, 2f, 12f);
        }



            if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            movementSpeed = 1f;
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(114f, 127f, 219f, 255f);
            }
                
           
        }
        else
        {
            GetComponent<Renderer>().material.color = new Color(51f, 51f, 51f, 1f);
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).GetComponent<Renderer>().material.color = current;
            }

            movementSpeed = 20f;
        }

    }

    public void setTime(int timeRemaining) => this.timeRemaining = timeRemaining;
}


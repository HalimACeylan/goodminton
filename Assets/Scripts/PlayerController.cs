using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Movement speed of the player
    public static bool playerBegin;
    private Rigidbody rb;
    // Reference to the Rigidbody component
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
        if (playerBegin)
        {
            transform.position = new Vector3(3f, 2f, -8f);
            // Reset velocity to zero
            rb.velocity = Vector3.zero;
            // Reset angular velocity to zero
            rb.angularVelocity = Vector3.zero;
            playerBegin = false;
        }
    }
}

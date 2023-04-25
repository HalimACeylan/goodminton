using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NpcRandomController : MonoBehaviour
{
    public float movementRange = 5f; // Range of movement in x-axis
    public float movementSpeed = 10f; // Speed of movement

    private Vector3 originalPosition;
    private float targetPositionX;

    void Start()
    {
        originalPosition = transform.position;
        UpdateTargetPosition();
    }

    void Update()
    {
        // Move towards the target position
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetPositionX, transform.position.y, transform.position.z), movementSpeed * Time.deltaTime);

        // Check if reached the target position
        if (transform.position.x == targetPositionX)
        {
            UpdateTargetPosition();
        }
    }

    void UpdateTargetPosition()
    {
        // Generate a random target position within the movement range
        targetPositionX = originalPosition.x + Random.Range(-movementRange, movementRange);
    }
}

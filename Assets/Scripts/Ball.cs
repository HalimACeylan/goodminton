using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Rigidbody ballRigidbody;
    private float centerOfMass = 1f;
    private Vector3 ballPlayerResetPoint;
    private Vector3 ballAiResetPoint;
    public float rotationSpeed = 100f;
    public GameObject gameManagerScript;
    public bool isLastHitByAi = false;
    public bool isTurnAi = false;
    // Start is called before the first frame update
    public global::System.Single CenterOfMass { get => centerOfMass; set => centerOfMass = value; }

    void Start()
    {   
        ballPlayerResetPoint = new Vector3(5.4f, 8.2f, -14.8f);
        ballAiResetPoint = new Vector3(-4.4f, 8.2f, 9.2f);
        gameManagerScript = GameObject.Find("GameManager");
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

            if(collision.gameObject.transform.name == "Player")
            {
                isLastHitByAi = false;

            }else
            {
                isLastHitByAi = true;
            }
            ballRigidbody.velocity = Vector3.zero; // Stop the ball character's movement
            ballRigidbody.angularVelocity = Vector3.zero;
            // Get direction away from the player
            Vector3 direction = transform.position - collision.gameObject.transform.position;
            direction.y = 6f; // Remove the vertical component for a 2D-like parabolic trajectory
            // Normalize the direction
            direction.Normalize();
            // Apply force to the ball in the direction away from the player
            Vector3 force = direction * 5f; // Adjust the force based on desired strength
            ballRigidbody.AddForce(force, ForceMode.Impulse);

        }
        else if (collision.gameObject.CompareTag("Border"))
        {
            isTurnAi = Score();
             Turn(isTurnAi);

        }
        else if (collision.gameObject.CompareTag("ground"))
        {
                if (transform.position.z > -1.8f)
                {
                    isLastHitByAi = true;
                    isTurnAi = Score();
                    Turn(isTurnAi);

                }
                else
                {
                    isLastHitByAi = false;
                    isTurnAi = Score();
                    Turn(isTurnAi);

                }
        }
        else{
            Vector3 collisionNormal = collision.contacts[0].normal;
        }

        if (collision.gameObject.CompareTag("Net"))
        {
            isTurnAi = Score();
            Turn(isTurnAi);

        }
    }

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

        
        if(transform.position.y >= 16.50)
        {
            isTurnAi = Score();
            Turn(!isTurnAi);
        }
    }
    private bool Score()
    {
       return gameManagerScript.GetComponent<GameManagerScript>().incrementScore(isLastHitByAi);
    }
    private void Turn(bool isTurnAi)
    {
        ballRigidbody.velocity = Vector3.zero;
        ballRigidbody.angularVelocity = Vector3.zero;
        if (isTurnAi)
        {
            transform.position = ballAiResetPoint;
        }
        else
        {
            transform.position = ballPlayerResetPoint;
        }
    }
}

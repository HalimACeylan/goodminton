using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{
    public float delay = 2.0f; // Delay in seconds before destroying the collectible

    void Start()
    {
        // Start the coroutine to remove the collectible after a delay
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log(other.gameObject.transform.parent.name + "collect a box");
        }
        else
        {
            StartCoroutine(DestroyCollectible());
            IEnumerator DestroyCollectible()
            {
                // Wait for the specified delay
                yield return new WaitForSeconds(delay);

                // Destroy the collectible game object
                Destroy(gameObject);
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Collect : MonoBehaviour
{
    private WindZone windController;
    private GameObject windZone;
    public float delay = 2.0f; // Delay in seconds before destroying the collectible
    public bool amIBlue = false; 
    void Start()
    {
        // Start the coroutine to remove the collectible after a delay

        windZone = GameObject.Find("WindZone");
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
            if(amIBlue)
            {
                windZone.GetComponent<WindZone>().strangthDecrement();

            }
            else
            {
                windZone.GetComponent<WindZone>().strangthIncrement();

            }
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

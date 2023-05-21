using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitbyProjectile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log(other.gameObject.tag + "hit by projectile");
        }else if(other.gameObject.tag == "Border")
        {
            Destroy(gameObject);
            Debug.Log(other.gameObject.tag + "hit by projectile");

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMovement : MonoBehaviour
{
    public float projectileSpeed = 40.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(projectileSpeed * Time.deltaTime * Vector3.back);
        if(transform.position.z > 20 && gameObject != null)
        {
            Destroy(gameObject);
        }
    }
}

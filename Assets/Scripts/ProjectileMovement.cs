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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            Debug.Log(other.gameObject.tag + "hit by projectile");
            other.gameObject.transform.parent.GetComponent<NpcRandomController>().setTime(10);

        }

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

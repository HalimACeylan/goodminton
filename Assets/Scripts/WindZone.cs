using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindZone : MonoBehaviour
{
    public bool isLeft = false;
    public float strength = 1f;
    public GameObject rightPartic;
    public GameObject leftPartic;
    // Start is called before the first frame update
    void Start()
    {

        rightPartic = this.gameObject.transform.GetChild(1).GetChild(0).gameObject;
        leftPartic = this.gameObject.transform.GetChild(0).GetChild(0).gameObject;
        leftPartic.GetComponent<ParticleSystem>().Stop();
        rightPartic.GetComponent<ParticleSystem>().Stop();


    }
    void FixedUpdate()
    {
    }
    public void strangthIncrement() {
        strength = strength + 0.2f;
    }
    public void strangthDecrement()
    {
        strength = strength - 0.2f;
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rigidbody playerRb = other.gameObject.GetComponentInParent<Rigidbody>();
           if (playerRb != null)
            {
                playerRb.AddForce(strength * 1.3f , 0, 0, ForceMode.Impulse);
            }

        }
        else if(other.gameObject.tag == "Ball")
        {
            Rigidbody ballRb = other.gameObject.GetComponentInParent<Rigidbody>();
            ballRb.AddForce(strength / 70, 0, 0, ForceMode.Impulse);

        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        if ( strength != 0)
        {
            isLeft = strength < 0;

            if (isLeft)
            {
                rightPartic.GetComponent<ParticleSystem>().Stop();
                var emission = leftPartic.GetComponent<ParticleSystem>().emission;
                emission.rateOverTime = -strength * 5f;
                leftPartic.GetComponent<ParticleSystem>().Play();
            }
            else
            {
                leftPartic.GetComponent<ParticleSystem>().Stop();
                var emission = rightPartic.GetComponent<ParticleSystem>().emission;
                emission.rateOverTime = strength * 5;
                rightPartic.GetComponent<ParticleSystem>().Play();

            }
        }
        if(strength > 1)
        {
            strength = 1;
        }if(strength < -1)
        {
            strength = -1;
        }
    }
}

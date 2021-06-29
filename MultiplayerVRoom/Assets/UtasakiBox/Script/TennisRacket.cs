using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacket : MonoBehaviour
{
    public GameObject ball;

    private Rigidbody rb;

    private float power = 3.0f;

    private void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ball")
        {
            Vector3 Force;
            Force = rb.velocity * power;
            Debug.Log(Force);
            ball.GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse);
        }
    }
}

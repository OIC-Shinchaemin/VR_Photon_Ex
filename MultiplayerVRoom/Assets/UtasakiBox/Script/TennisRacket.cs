using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TennisRacket : MonoBehaviour
{
    public GameObject Ball;
    private float speedZ = 1.8f;
    private float speedY = 0.6f;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Ball")
        {
            Vector3 Force;
            Force = new Vector3(0, speedY, speedZ);
            Ball.GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse);
        }
    }
}

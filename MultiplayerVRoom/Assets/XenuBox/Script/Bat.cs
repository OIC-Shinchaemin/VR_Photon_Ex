using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : MonoBehaviour
{
    [SerializeField]private AudioSource Hit;
    private float power = 1.5f;

       private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag=="Ball")
        {
            Hit.Play();
            Vector3 Force;
            Force = rb.velocity * power;
            Debug.Log(Force);
            col.gameObject.GetComponent<Rigidbody>().AddForce(Force, ForceMode.Impulse);
        }
    }
}

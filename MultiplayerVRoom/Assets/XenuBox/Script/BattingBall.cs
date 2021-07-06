using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingBall : MonoBehaviour
{

    [SerializeField] AudioSource miss;
    [SerializeField] AudioSource homerun;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0, 5.5f, -25);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            //miss.Play();
            //Destroy(gameObject);
        }
        if(collision.gameObject.tag == "HomeRunArea")
        {
            homerun.Play();
            //Destroy(gameObject);
        }

    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingBall : MonoBehaviour
{

    [SerializeField] AudioSource miss;
    [SerializeField] AudioSource homerun;
    private bool hit;
    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(0, 0, -10);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Bat")
        {
            hit = true;
        }

        if(collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
            Debug.Log("消えました（ガチギレ）"+transform.position);
        }
        if(collision.gameObject.tag == "HomeRunArea")
        {
            homerun.Play();
            //Destroy(gameObject);
        }

    }

}

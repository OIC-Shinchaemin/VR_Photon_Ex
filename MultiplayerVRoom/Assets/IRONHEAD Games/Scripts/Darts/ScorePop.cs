using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePop : MonoBehaviour
{
    private float sec;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        sec += Time.deltaTime;
        if (sec >= 0.5) 
        {
            rb.velocity = Vector3.zero;
            if(sec >= 1)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            rb.velocity = new Vector3(0, 1, 0);
        }
    }
}

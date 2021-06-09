using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DartsBall : MonoBehaviour
{

    private Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame
    private void OnCollisionEnter(Collision other)
    {
        Destroy(gameObject);
        
    }
}

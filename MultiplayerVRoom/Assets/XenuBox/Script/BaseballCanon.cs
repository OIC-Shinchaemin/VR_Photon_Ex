using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballCanon : MonoBehaviour
{

    private float time;
    [SerializeField] private GameObject Baseball;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>=10)
        {
            Instantiate(Baseball, transform.position, transform.rotation);
            time = 0;
        }
    }
}

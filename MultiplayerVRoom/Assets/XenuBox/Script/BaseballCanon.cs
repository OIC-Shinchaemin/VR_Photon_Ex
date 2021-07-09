using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseballCanon : MonoBehaviour
{
    
    private float time;
    [SerializeField] private GameObject Baseball;
    float x;

    // Update is called once per frame
    private void Awake()
    {

        Random.InitState(System.DateTime.Now.Millisecond);
    }
    void Update()
    {

        time += Time.deltaTime;

        x = Random.Range(15.0f, 18.0f);



        if (time>=10)
        {
            Instantiate(Baseball, new Vector3(x, 2.05008f, 28.0f), transform.rotation);
            time = 0;
        }
    }
}

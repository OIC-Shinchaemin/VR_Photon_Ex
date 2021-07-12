using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextClearTimer : MonoBehaviour
{
    private float time;
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if(time>=1.0f)
        {
            BaseballManager.baseball.Pop.text = "";
            Destroy(gameObject);
        }
    }
}

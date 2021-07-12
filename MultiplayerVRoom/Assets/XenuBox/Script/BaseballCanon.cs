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
        if(BaseballManager.baseball.IsShooting == false)
        {
            time += Time.deltaTime;
        }

        if(time>=5 && BaseballManager.baseball.IsShooting == false && BaseballManager.baseball.BallCount >= 10)
        {
            BaseballManager.baseball.GameSet();
            time = 0;
        }
        else if (time>=1 && BaseballManager.baseball.IsShooting == false && BaseballManager.baseball.BallCount <10)
        {
            x = Random.Range(15.5f, 17.5f);

            Instantiate(Baseball, new Vector3(x, 2.05008f, 28.0f), transform.rotation);
            time = 0;
            BaseballManager.baseball.IsShooting = true;
        }
        
    }
}

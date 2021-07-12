using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattingBall : MonoBehaviour
{

    [SerializeField] AudioSource miss;
    [SerializeField] AudioSource homerun;
    private bool hit;
    private Rigidbody rb;
    [SerializeField] GameObject soundcube;
    [SerializeField] GameObject TextClearTimer;

    
    private int speed;

    private void Awake()
    {
        Random.InitState(System.DateTime.Now.Millisecond);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        speed = Random.Range(-20, -15);

        rb.velocity = new Vector3(0, 0, speed);
    }

    private void OnCollisionEnter(Collision collision)
    {

        if(collision.gameObject.tag == "Bat")
        {
            hit = true;
        }

        if(collision.gameObject.tag == "Floor")
        {
            if(hit)
            {
                BaseballManager.baseball.Pop.text = "HIT";
                Instantiate(TextClearTimer, transform.position, transform.rotation);
            }
            BaseballManager.baseball.IsShooting = false;
            BaseballManager.baseball.BallCount += 1;
            Destroy(gameObject);
            
        }
        if(collision.gameObject.tag == "Wall")
        {
            if(!hit)
            {
                BaseballManager.baseball.Pop.text = "STRIKE...";
                Instantiate(TextClearTimer, transform.position, transform.rotation);
                BaseballManager.baseball.IsShooting = false;
                BaseballManager.baseball.BallCount += 1;
                Destroy(gameObject);
            }
            else
            {
                BaseballManager.baseball.Pop.text = "Foul...";
                Instantiate(TextClearTimer, transform.position, transform.rotation);
                BaseballManager.baseball.IsShooting = false;
                BaseballManager.baseball.BallCount += 1;
                Destroy(gameObject);
            }
        }
        if(collision.gameObject.tag == "HomeRunArea")
        {
            BaseballManager.baseball.Pop.text = "HOMERUN!!!!";
            BaseballManager.baseball.HomeRunCount += 1;
           
            Instantiate(soundcube,transform.position,transform.rotation);
            BaseballManager.baseball.IsShooting = false;
            BaseballManager.baseball.BallCount += 1;
            Destroy(gameObject);
        }

    }

}

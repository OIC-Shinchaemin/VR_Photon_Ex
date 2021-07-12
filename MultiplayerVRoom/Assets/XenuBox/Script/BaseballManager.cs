using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BaseballManager : MonoBehaviour
{

    public int HomeRunCount;
    public TextMeshProUGUI LastScore;
    public TextMeshProUGUI Pop;
    public int BallCount;
    public static BaseballManager baseball;

    private AudioSource SE_GameStart;

    public GameObject Hide_Title;
    public GameObject Hide_HomeRunText;

    public GameObject Hide_Button;
    public GameObject Hide_MaxCount;
    public GameObject Hide_Back;


    public bool IsShooting;
    void Start()
    {
        SE_GameStart = GetComponent<AudioSource>();
        IsShooting = true;
        baseball = this;
    }

    public void GameStart()
    {
        HomeRunCount = 0;
        BallCount = 0;
        LastScore.text = "";
        Hide_Button.SetActive(false);
        Hide_HomeRunText.SetActive(false);
        Hide_MaxCount.SetActive(false);
        Hide_Title.SetActive(false);
        Hide_Back.SetActive(false);
        SE_GameStart.Play();
        IsShooting = false;
    }

    public void GameSet()
    {
        LastScore.text = HomeRunCount.ToString();
        Hide_Button.SetActive(true);
        Hide_HomeRunText.SetActive(true);
        Hide_MaxCount.SetActive(true);
        Hide_Title.SetActive(true);
        Hide_Back.SetActive(true);
        IsShooting = true;
    }

}

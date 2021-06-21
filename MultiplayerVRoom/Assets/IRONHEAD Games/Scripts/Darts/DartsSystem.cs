using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DartsSystem : MonoBehaviour
{
    public int Score;
    public int BallsCount;

    public TextMeshProUGUI BallsAmount;
    public static DartsSystem DS;

    public GameObject GameBord;

    public GameObject ScoreBord;

    public TextMeshProUGUI ScoreAmount;
    public TextMeshProUGUI LastScore;

    public GameObject DartsBall;

    // Start is called before the first frame update
    void Start()
    {
        DS = this;
        
    }

    // Update is called once per frame
    private void Update()
    {
        //ボールの残りの数が0になったら終われ。
        if (BallsCount == 0) 
        {
            GameEnd();
        }
    }
    //ゲーム開始時の処理。
    public void GameStart()
    {

        GameBord.SetActive(false);
        ScoreBord.SetActive(true);
        Score = 0;
        ScoreAmount.text = "0";
        BallsCount = 3;
        BallsAmount.text = BallsCount.ToString();

        //ここでボールが３つ生成される。
        for(int i=0;i<3;i++)
        {
            Instantiate(DartsBall, new Vector3(-2f, 1.98f, -1.25f-(i*0.5f)), Quaternion.identity);
        }
    }

    //終了時の処理
   private void GameEnd()
   {
        ScoreBord.SetActive(false);
        GameBord.SetActive(true);
        LastScore.text = Score.ToString();
   }




}

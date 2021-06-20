using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DartsSystem : MonoBehaviour
{
    public int Score;
    public int ThrowCount;
    public static DartsSystem DS;

    public GameObject StartButton;

    public TextMeshProUGUI ScoreText;

    public GameObject DartsBall;

    // Start is called before the first frame update
    void Start()
    {
        DS = this;
    }

    // Update is called once per frame
    private void Update()
    {
        if(ThrowCount >=3)
        {
            GameEnd();
        }
    }

    public void GameStart()
    {
        StartButton.SetActive(false);
        Score = 0;
        ScoreText.text = "0";
        ThrowCount = 0;

        for(int i=0;i<3;i++)
        {
            Instantiate(DartsBall, new Vector3(-2f, 1.98f, -1.25f-(i*0.5f)), Quaternion.identity);
        }
    }

   private void GameEnd()
   {
        StartButton.SetActive(true);
   }




}

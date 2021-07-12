using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : MonoBehaviour
{
    int score1p = 0;
    int score2p = 0;

    public TextMeshPro scoreText1p;
    public TextMeshPro scoreText2p;

    public void OnClicked1pUp()
    {
        if (score1p < 99)
        {
            score1p++;
            Debug.Log("ifok");
        }
        Debug.Log("clickok");
    }

    public void OnClicked1pDown()
    {
        if (score1p < 0)
        {
            score1p--;
        }
    }
    public void OnClicked2pUp()
    {
        if (score2p < 99)
        {
            score2p++;
        }
    }

    public void OnClicked2pDown()
    {
        if (score2p < 0)
        {
            score2p--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        scoreText1p.text = score1p.ToString("D2");
        scoreText2p.text = score2p.ToString("D2");
    }
}

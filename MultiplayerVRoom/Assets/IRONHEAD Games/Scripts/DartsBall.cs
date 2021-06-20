using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DartsBall : MonoBehaviour
{

    private Collider coll;

    private bool Score100;
    private bool Score30;
    private bool Score10;
    private bool ScoreHinekure;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider>();
    }

    // Update is called once per frame

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Target100")
        {
            Score100 = true;
            Debug.Log("Target100");


        }
        if (other.gameObject.tag == "Target30")
        {
            Score30 = true;
            Debug.Log("Target30");

        }
        if (other.gameObject.tag == "Target10")
        {
            Score10 = true;
            Debug.Log("Target10");

        }
        if (other.gameObject.tag == "Target???")
        {
            ScoreHinekure = true;

        }
        if(other.gameObject.tag == "Wall")
        {
            if(Score100)
            {
                Debug.Log("はい、罰金100万円");
                DartsSystem.DS.Score += 100;
            }
            else if(Score30)
            {
                Debug.Log("はい、30万ベルだなも。");
                DartsSystem.DS.Score += 30;
            }
            else if(Score10)
            {
                Debug.Log("10円!!");
                DartsSystem.DS.Score += 10;
            }
            else if(ScoreHinekure)
            {
                Debug.Log("捻くれてますねぇ");
                DartsSystem.DS.Score += 500;
            }
            else
            {
                Debug.Log("はい。死んでください");
            }
            DartsSystem.DS.ThrowCount += 1;
            DartsSystem.DS.ScoreText.text = DartsSystem.DS.Score.ToString();
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target100")
        {
            Score100 = false;
            Debug.Log("100ゾーンから抜けた");
        }
        if (other.gameObject.tag == "Target30")
        {
            Score30 = false;
            Debug.Log("30ゾーンから抜けた");
        }
        if (other.gameObject.tag == "Target10")
        {
            Score10 = false;
            Debug.Log("10ゾーンから抜けた");
        }
        if (other.gameObject.tag == "Target???")
        {
            ScoreHinekure = false;
        }
    }

}

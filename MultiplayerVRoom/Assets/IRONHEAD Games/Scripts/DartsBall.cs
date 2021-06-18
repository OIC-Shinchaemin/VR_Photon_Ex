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

    public TextMeshProUGUI Score;

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
            Score.text = "100";
        }
        if (other.gameObject.tag == "Target30")
        {
            Score30 = true;
            Debug.Log("Target30");
            Score.text = "30";
        }
        if (other.gameObject.tag == "Target10")
        {
            Score10 = true;
            Debug.Log("Target10");
            Score.text = "10";
        }
        if (other.gameObject.tag == "Target???")
        {
            ScoreHinekure = true;
            Score.text = "捻くれてますねぇ";
        }
        if(other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Target100")
        {
            Score100 = false;
        }
        if (other.gameObject.tag == "Target30")
        {
            Score30 = false;
        }
        if (other.gameObject.tag == "Target10")
        {
            Score10 = false;
        }
        if (other.gameObject.tag == "Target???")
        {
            ScoreHinekure = false;
        }
    }

}

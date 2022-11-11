using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    //Based on https://youtu.be/cOW_T3i4_kk

    public Text score;
    private int scoreNumber;

    void Start()
    {
        scoreNumber = 0;
        score.text = "Score: " + scoreNumber;
        
    }

    private void OnTriggerEnter(Collider Coin)
    {
        if(Coin.tag == "MyCoin")
        {
            scoreNumber++;
            Destroy(Coin.gameObject);
            score.text = "Score: " + scoreNumber;
        }
    }
}

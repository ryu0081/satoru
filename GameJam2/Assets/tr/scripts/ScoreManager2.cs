using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public HPManger[] hpM;

    int eScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        AddScore();
    }

    void AddScore()
    {
        eScore += hpM[0].eScore;
        eScore += hpM[1].eScore;
        eScore += hpM[2].eScore;
        eScore += hpM[3].eScore;


        GetComponent<Text>().text = eScore.ToString();
    }
}

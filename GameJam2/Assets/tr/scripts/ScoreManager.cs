using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public HPManger[] hpM;

    float pScore = 0;
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
        pScore += hpM[0].pScore;
        pScore += hpM[1].pScore;
        pScore += hpM[2].pScore;
        pScore += hpM[3].pScore;

        GetComponent<Text>().text = Mathf.Ceil(pScore).ToString();
    }
}

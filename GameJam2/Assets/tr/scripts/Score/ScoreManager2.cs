using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager2 : MonoBehaviour
{
    public HPManger[] hpM;

    float eScore = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (camerasystem.cameraON)
        {
            AddScore();
        }
    }

    void AddScore()
    {
        eScore += hpM[0].eScore;
        eScore += hpM[1].eScore;
        eScore += hpM[2].eScore;
        eScore += hpM[3].eScore;


        GetComponent<Text>().text = Mathf.Ceil(eScore).ToString();
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResultScore : MonoBehaviour
{
    ScoreManager sm;
    ScoreManager2 sm2;

    public GameObject scoreP;
    public GameObject scoreE;

    float pscore;
    float escore;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Score();
    }

    void Score()
    {
        pscore = sm.pScore;
        escore = sm2.eScore;

        scoreP.GetComponent<Text>().text = pscore.ToString();
        scoreE.GetComponent<Text>().text = escore.ToString();
    }
}

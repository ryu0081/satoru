using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battlec : MonoBehaviour
{
    public HPManger[] hm;
    bool[] isBreak = new bool[4];
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Result();
    }

    void Result()
    {
        isBreak[0] = hm[0].isFinish;
        isBreak[1] = hm[1].isFinish;
        isBreak[2] = hm[2].isFinish;
        isBreak[3] = hm[3].isFinish;

        if(isBreak[0] && isBreak[1] && isBreak[2] && isBreak[3])
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Battlec : MonoBehaviour
{
    public GameObject[] build;
    bool[] isBreak;
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
        isBreak[0] = build[0];
        isBreak[1] = build[1];
        isBreak[2] = build[2];
        isBreak[3] = build[3];

        if(isBreak[0] && isBreak[1] && isBreak[2] && isBreak[3])
        {
            SceneManager.LoadScene("ResultScene");
        }
    }
}

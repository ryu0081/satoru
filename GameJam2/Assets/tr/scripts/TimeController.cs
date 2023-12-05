using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    int m;
    float s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        cntTime();
    }

    void cntTime()
    {
        s += Time.deltaTime;
        if (s>=60)
        {
            m++;
            s = 0;
        }
        GetComponent<Text>().text = m.ToString() + "\n" + Mathf.Ceil(s).ToString();
    }
}

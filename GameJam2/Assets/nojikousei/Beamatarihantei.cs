using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beamatarihantei : MonoBehaviour
{
    float time = 0;
    public GameObject efecthantei;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time>=6f)
        {
            efecthantei.SetActive(true);
        }
    }
}

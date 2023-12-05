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
        StartCoroutine("hantei");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator hantei()
    {
        yield return new WaitForSeconds(6.0f);
        efecthantei.SetActive(true);
    }
}

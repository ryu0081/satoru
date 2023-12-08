using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titlescript : MonoBehaviour
{
    public GameObject [] Camera;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    IEnumerator Cameraroot()
    {
        for (int i = 0; i < 4; i++)
        {
            Debug.Log("‚¨‚ß‚Å‚Æ‚¤");
            Camera[i].SetActive(false);
            yield return new WaitForSeconds(10.0f);

        }
        Camera[0].SetActive(true);
        Camera[1].SetActive(true);
        Camera[2].SetActive(true);
        Camera[3].SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("Cameraroot");
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IconController : MonoBehaviour
{
    float red = 255;

    bool button1;
    bool button2;
    bool button3;

    public GameObject[] Icon;

    void Start()
    {
        Icon[0].GetComponent<Image>().color = new Color(255, 0, 0, 255);        //1を押したら2と3をオフにする
    }

    void Update()
    {
        IconCo();
    }

    void IconCo()
    {
        if (Input.GetKey(KeyCode.Alpha1))
        {
            button1 = true;

            button2 = false;
            button3 = false;
        }
        if (Input.GetKey(KeyCode.Alpha2))
        {
            button2 = true;

            button1 = false;
            button3 = false;

        }
        if (Input.GetKey(KeyCode.Alpha3))
        {
            button3 = true;

            button1 = false;
            button2 = false;

        }

        if (button1)
        {
            Debug.Log("1");
            red -= 50;
            Icon[0].GetComponent<Image>().color = new Color(255, red, red, 255);        //1を押したら2と3をオフにする

            Icon[1].GetComponent<Image>().color = new Color(255, 255, 255, 255);        
            Icon[2].GetComponent<Image>().color = new Color(255, 255, 255, 255);

        }
        if (button2)
        {
            Debug.Log("2");

            red -= 50;
            Icon[1].GetComponent<Image>().color = new Color(255, red, red, 255);        //2を押したら1と3をオフにする

            Icon[0].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            Icon[2].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
        if (button3)
        {
            Debug.Log("3");

            red -= 50;
            Icon[2].GetComponent<Image>().color = new Color(255, red, red, 255);        //3を押したら1と2をオフにする

            Icon[1].GetComponent<Image>().color = new Color(255, 255, 255, 255);
            Icon[0].GetComponent<Image>().color = new Color(255, 255, 255, 255);
        }
    }
}
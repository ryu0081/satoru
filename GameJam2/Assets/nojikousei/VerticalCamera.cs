using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    float anglespeed = 1;
    Vector3 angle;
    public float anglestop = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Verticalangle();
    }
    void Verticalangle()
    {
        angle += new Vector3(Input.GetAxisRaw("Mouse Y"), 0, 0);
        transform.localEulerAngles= -angle;
        if (angle.x >= anglestop)
        {
            angle.x = anglestop;
        }
        if (angle.x <= -anglestop)
        {
            angle.x = -anglestop;
        }
    }
}

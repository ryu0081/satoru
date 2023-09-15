using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalCamera : MonoBehaviour
{
    float anglespeed = 1;
    float angle;
    public float anglestop = 30f;
    public GameObject player;
    Vector3 PlayerPos;
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
        angle = Input.GetAxis("Mouse Y");
        //transform.localEulerAngles= -angle;
        PlayerPos = player.transform.position;
        transform.RotateAround(PlayerPos, Vector3.left, angle);

    }
}

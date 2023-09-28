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
    //Quaternion rotate;
    Vector3 rotate;
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

        rotate = transform.localEulerAngles;
        // ���̂܂܂̊p�x���Ǝg���ɂ������߁A-180�`180�ɕϊ�����
        rotate.x = Mathf.Repeat(rotate.x + 180, 360) - 180;

        Debug.Log("rotate.x :" + rotate.x);

        if (rotate.x >  anglestop)
        {
            angle = angle < 0f ? 0f : angle;
        }
        if(rotate.x < -anglestop)
        {
            angle = angle > 0f ? 0f : angle;

        }
        transform.RotateAround(PlayerPos, Vector3.left, angle);
        transform.LookAt(PlayerPos);
        //���邮�邷��Ƃ�����ƃo�O��
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Openpanel : MonoBehaviour
{
    public GameObject panel; // �p�l���̎Q��


    // �{�^�����N���b�N���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    public void ShowPanel()
    {
        panel.SetActive(true); // �p�l����\������
    }

}

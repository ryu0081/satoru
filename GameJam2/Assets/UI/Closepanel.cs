using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closepanel : MonoBehaviour
{
    public GameObject panel; // ����Ώۂ̃p�l��

    // �p�l������郁�\�b�h
    public void ClosePanel()
    {
        panel.SetActive(false); // �p�l�����\���ɂ���
    }
}

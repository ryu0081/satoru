using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpgauge : MonoBehaviour
{
    public Transform target; // �L�����N�^�[�̓���Transform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            // �L�����N�^�[�̓��̈ʒu��HP�o�[��Ǐ]
            transform.position = target.position;
        }
    }
}

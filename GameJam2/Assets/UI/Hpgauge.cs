using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hpgauge : MonoBehaviour
{
    public Transform target; // キャラクターの頭のTransform

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (target != null)
        {
            // キャラクターの頭の位置にHPバーを追従
            transform.position = target.position;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPbarController : MonoBehaviour
{
    [SerializeField] private Transform playerObj;
    [SerializeField] private Transform[] hpObj;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hpObj[0].LookAt(playerObj);
        hpObj[1].LookAt(playerObj);
        hpObj[2].LookAt(playerObj);
        hpObj[3].LookAt(playerObj);
    }
}

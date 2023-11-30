using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManger : MonoBehaviour
{
    public buildController[] bc;

    bool isBeam = false;

    float damage = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        isBeam = bc[0].isBeam;
        isBeam = bc[1].isBeam;
        isBeam = bc[2].isBeam;
        isBeam = bc[3].isBeam;
        Debug.Log(isBeam);
        HP();
    }

    void HP()
    {
        if (isBeam)
        {
            GetComponent<Image>().fillAmount -= damage;
        }
    }
}

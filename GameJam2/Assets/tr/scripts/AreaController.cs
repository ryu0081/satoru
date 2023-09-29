using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class AreaController : MonoBehaviour
{
    public buildController bc;

    bool isBeam = false;

    Vector3 pos;

    public GameObject hpGauge;

    float damage = 0.01f;
    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;
        Instantiate(hpGauge, pos += new Vector3(0.0f, 10.0f, 0.0f), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        isBeam = bc.isBeam;
        hp();
    }

    void hp()
    {
        if (isBeam)
        {
            hpGauge.GetComponent<Image>().fillAmount -= damage;
        }
    }
}

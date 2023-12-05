using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimecs : MonoBehaviour
{
    public GameObject[] skillTime;

    float sTime = 18.0f;
    float bTime = 4.0f;
    float hTime = 3.0f;
    float time = 0f;

    bool isSatoru = false;
    bool isBeam = false;
    bool homing = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Skill();
    }

    void Skill()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSatoru = true;
                time = sTime;

            }

        }

        if (isSatoru)
        {
            Debug.Log("A");
            skillTime[0].GetComponent<Text>().text = time.ToString("n2");
            if (time <= 0.0f)
            {
                isSatoru = false;
                time = 0.0f;
            }
            time -= Time.deltaTime;

        }
    }
}

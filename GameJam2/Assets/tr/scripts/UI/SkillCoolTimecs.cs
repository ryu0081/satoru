using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTimecs : MonoBehaviour
{
    public GameObject[] skillTime;

    int sTime = 18;
    int bTime = 4;
    int hTime = 3;

    bool isSatoru = false;
    bool isBeam = false;
    bool isHoming = false;
    bool isOne = false;
    bool isTwo = false;
    bool isThree = false;

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
        if(!isTwo && !isThree)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1)) isOne = true;
            if (Input.GetMouseButtonDown(0))
            {
                isSatoru = true;
            }

            if (isOne && isSatoru)
            {
                StartCoroutine("SatoruAT");
            }

        }

        if (!isOne && !isThree)
        {
            if (Input.GetKeyDown(KeyCode.Alpha2)) isTwo = true;
            if (Input.GetMouseButtonDown(0))
            {
                isBeam = true;
            }

            if (isTwo && isBeam)
            {
                Debug.Log("BB");
                StartCoroutine("BeamAT");
            }

        }



        if (!isTwo && !isOne)
        {
            if (Input.GetKeyDown(KeyCode.Alpha3)) isThree = true;
            if (Input.GetMouseButtonDown(0))
            {
                isHoming = true;
            }

            if (isThree && isHoming)
            {
                StartCoroutine("HomingAT");
            }

        }



    }

    IEnumerator SatoruAT()                                          //攻撃1のクールタイム
    {
        isOne = false;
        isSatoru = false;
        for(int i = sTime; i >= 0; i--)
        {
            if (i == 0)
            {
                skillTime[0].GetComponent<Text>().text = "";
                break;
            }

            skillTime[0].GetComponent<Text>().text = i.ToString();

            yield return new WaitForSeconds(1);
        }

    }

    IEnumerator BeamAT()                                        //攻撃2のクールタイム
    {
        isTwo = false;
        isBeam = false;
        for (int i = bTime; i >= 0; i--)
        {
            if (i == 0)
            {
                skillTime[1].GetComponent<Text>().text = "";
                break;
            }

            skillTime[1].GetComponent<Text>().text = i.ToString();

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator HomingAT()                                        //攻撃3のクールタイム
    {
        isTwo = false;
        isHoming = false;
        for (int i = hTime; i >= 0; i--)
        {
            if (i == 0)
            {
                skillTime[2].GetComponent<Text>().text = "";
                break;
            }

            skillTime[2].GetComponent<Text>().text = i.ToString();

            yield return new WaitForSeconds(1);
        }
    }
}

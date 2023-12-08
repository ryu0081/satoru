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
    bool isbefoS = false;
    bool isbefoB = false;
    bool isbefoH = false;

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
            isbefoS = true;
            if (isbefoH || isbefoB)                           //�O��2��3��������Ă�����false�ɂ���
            {
                isbefoB= false;
                isbefoH= false;

            }

            isOne = true;
        }
        if (Input.GetMouseButtonDown(0) && (isOne || isbefoS))
        {
            if (!isOne) isOne = true;

            isSatoru = true;
        }

        if (isOne && isSatoru)
        {
            StartCoroutine("SatoruAT");
        }



        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            isbefoB = true;

            if (isbefoS || isbefoH)                           //�O��1��3��������Ă�����false�ɂ���
            {
                isbefoS = false;
                isbefoH = false;
            }
            isTwo = true;
        }
        if (Input.GetMouseButtonDown(0) && isTwo || Input.GetMouseButtonDown(0) && isbefoB)
        {
            if (!isTwo) isTwo = true;

            isBeam = true;
        }

        if (isTwo && isBeam)
        {
            StartCoroutine("BeamAT");
        }




        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            isbefoH = true;
            if (isbefoS || isbefoB)                              //�O��1��2��������Ă�����false�ɂ���
            {

                isbefoS = false;
                isbefoB = false;

            }
            isThree = true;
        }
        if (Input.GetMouseButtonDown(0) && (isThree || isbefoH))
        {
            if (!isThree) isThree = true;
            isHoming = true;
        }

        if (isThree && isHoming)
        {
            StartCoroutine("HomingAT");
        }





    }

    IEnumerator SatoruAT()                                          //�U��1�̃N�[���^�C��
    {
        isOne = false;
        isSatoru = false;
        for (int i = sTime; i >= 0; i--)
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

    IEnumerator BeamAT()                                        //�U��2�̃N�[���^�C��
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

    IEnumerator HomingAT()                                        //�U��3�̃N�[���^�C��
    {
        isThree = false;
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

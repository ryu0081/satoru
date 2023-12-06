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
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (isThree || isTwo)                           //前に2か3を押されていたらfalseにする
            {
                isOne = false;
                isTwo = false;
            }

            isOne = true;
        }
        if (Input.GetMouseButtonDown(0) && isOne)
        {

            isSatoru = true;
        }

        if (isOne && isSatoru)
        {
            Debug.Log("1");
            StartCoroutine("SatoruAT");
        }



        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (isOne || isThree)                           //前に1か3を押されていたらfalseにする
            {
                isOne = false;
                isThree = false;
            }
            isTwo = true;
        }
        if (Input.GetMouseButtonDown(0) && isTwo)
        {
            isBeam = true;
        }

        if (isTwo && isBeam)
        {
            Debug.Log("2");
            StartCoroutine("BeamAT");
        }




        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if(isOne || isTwo)                              //前に1か2を押されていたらfalseにする
            {
                isOne = false;
                isTwo = false;
            }
            isThree = true;
        }
        if (Input.GetMouseButtonDown(0) && isThree)
        {
            isHoming = true;
        }

        if (isThree && isHoming)
        {
            Debug.Log("3");
            StartCoroutine("HomingAT");
        }





    }

    IEnumerator SatoruAT()                                          //攻撃1のクールタイム
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

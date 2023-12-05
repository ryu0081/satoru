using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasystem : MonoBehaviour
{
    public GameObject hennaCamera;
    public GameObject mainCamera;
    public GameObject sabCamera;
    public static bool satobe = true;
    public static bool jyakube = true;
    public static bool homingbe = true;
    int efectnunber = 0;
    public GameObject[] satoruEfect;
    public GameObject satoruSpoon;
    public GameObject player;
    
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
        //mainCamera.SetActive(false);
        //hennaCamera.SetActive(false);
        //sabCamera.SetActive(true);
    }
    IEnumerator ReturnSatoru()
    {
        satobe = false;
        yield return new WaitForSeconds(18.0f);
        satobe = true;
    }
    IEnumerator ReturnJyaku()
    {
        jyakube = false;
        yield return new WaitForSeconds(4.0f);
        jyakube = true;
    }
    IEnumerator ReturnHomi()
    {
        homingbe = false;
        yield return new WaitForSeconds(3.0f);
        homingbe = true;
    }
    public void Attack()
    {


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            efectnunber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            efectnunber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            efectnunber = 2;
        }

        if (Input.GetMouseButtonDown(0))
        {
            //player=GetComponent<Th>()
            switch (efectnunber)
            {
                case 0:
                    if (satobe)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[0], satoruSpoon.transform.position, transform.rotation);
                        obj.transform.parent = gameObject.transform;
                        Debug.Log("ÉrÅ[ÉÄíÜ");
                        StartCoroutine("ReturnSatoru");
                    }
                    break;
                case 1:
                    if (jyakube)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[1], satoruSpoon.transform.position, transform.rotation);
                        obj.transform.parent = gameObject.transform;
                        StartCoroutine("ReturnJyaku");
                    }
                    break;
                case 2:
                    if (homingbe)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[2], satoruSpoon.transform.position, transform.rotation);
                        obj.transform.parent = gameObject.transform;
                        StartCoroutine("ReturnHomi");
                    }

                    break;
            }



            //çUåÇèàóùÇÇ±Ç±Ç…èëÇ≠ÅB
            //Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
            //gameObject.transform.parent = satoruEfect.gameObject.transform;
        }

    }
}

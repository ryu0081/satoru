using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerasystem : MonoBehaviour
{
    public GameObject hennaCamera;
    public GameObject sabCamera;
    public static bool satobe = true;
    public static bool jyakube = true;
    public static bool homingbe = true;
    public static bool cameraON = true;
    int efectnunber = 3;
    public GameObject[] satoruEfect;
    public GameObject satoruSpoon;
    public GameObject player;
    Animator animator;
    
    GameObject obj;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
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
    IEnumerator CameraON()
    {
        cameraON = false;
        animator.SetBool("Beam",true);
        hennaCamera.SetActive(false);
        
        yield return new WaitForSeconds(10.0f);
        hennaCamera.SetActive(true);
        animator.SetBool("Beam", false);
        cameraON = true;
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
            
            switch (efectnunber)
            {
                case 0:
                    if (satobe)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[0], satoruSpoon.transform.position, transform.rotation);
                        obj.transform.parent = gameObject.transform;
                        
                        StartCoroutine("ReturnSatoru");
                        StartCoroutine("CameraON");
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
                case 3:
                    break;
            }



            //çUåÇèàóùÇÇ±Ç±Ç…èëÇ≠ÅB
            //Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
            //gameObject.transform.parent = satoruEfect.gameObject.transform;
        }

    }
}

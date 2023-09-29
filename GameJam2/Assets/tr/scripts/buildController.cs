using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -0.2f;

    public bool isBeam = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isBeam) fall();
    }

    void fall()
    {
        transform.position += new Vector3(0.0f, speed, 0.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Beam")
        {
            isBeam = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Beam")
        {
            isBeam = false;
        }
    }
}

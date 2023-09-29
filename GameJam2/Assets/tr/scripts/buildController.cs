using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -0.2f;
    public bool isFall = true;
    public bool isBeam = false;
    //倒したときのエフェクト
    public GameObject breakEffect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isFall) fall();
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
            //エフェクトを発生させる
            GenerateEffect();
        }
    }
    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.collider.gameObject.tag == "Beam")
        {
            isBeam = false;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -2.0f;

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
        if (isBeam) fall();
    }

    void fall()
    {
        transform.position += new Vector3(0.0f, speed, 0.0f);
    }

    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            isBeam = true;
            //エフェクトを発生させる
            GenerateEffect();
        }
    }

}

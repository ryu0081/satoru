using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -2.0f;

    public bool isDamage = false;
    public bool isEnemy = false;
    public bool isPlayer = false;

    //倒したときのエフェクト
    public GameObject breakEffect;
    GameObject effect;
    bool satorub;

    Vector3 pos = new Vector3(0.0f, 20.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        satoruB();
    }

    void satoruB()
    {
        satorub = camerasystem.cameraON;
        if (satorub)
        {
            isDamage = false;                   //ビームを撃ってない時、false
            Destroy(effect);
        }
        else
        {
            isDamage = true;                    //ビームを撃っている時、true
        }
    }


    //エフェクトを生成する
    void GenerateEffect()
    {
        //エフェクトを生成する
        effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = pos + gameObject.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            isPlayer = true;
            isDamage = true;
            //エフェクトを発生させる
            GenerateEffect();
        }else if(other.gameObject.tag == "Enemy")
        {
            isEnemy = true;
            isDamage = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beam" || other.gameObject.tag == "Enemy")
        {
            isDamage = false;
            Destroy(effect);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -2.0f;

    public bool isDamage = false;
    public bool isEnemy = false;
    public bool isPlayer = false;

    //�|�����Ƃ��̃G�t�F�N�g
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
            isDamage = false;                   //�r�[���������ĂȂ����Afalse
            Destroy(effect);
        }
        else
        {
            isDamage = true;                    //�r�[���������Ă��鎞�Atrue
        }
    }


    //�G�t�F�N�g�𐶐�����
    void GenerateEffect()
    {
        //�G�t�F�N�g�𐶐�����
        effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = pos + gameObject.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            isPlayer = true;
            isDamage = true;
            //�G�t�F�N�g�𔭐�������
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

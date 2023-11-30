using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -2.0f;

    public bool isBeam = false;
    //�|�����Ƃ��̃G�t�F�N�g
    public GameObject breakEffect;

    Vector3 pos = new Vector3(0.0f, 20.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void fall()
    {
        transform.position += new Vector3(0.0f, speed, 0.0f);
    }

    //�G�t�F�N�g�𐶐�����
    void GenerateEffect()
    {
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
        effect.transform.position = pos += gameObject.transform.position;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            isBeam = true;
            //�G�t�F�N�g�𔭐�������
            GenerateEffect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Beam")
        {
            isBeam = false;
            //�G�t�F�N�g�𔭐�������
        }
    }

}

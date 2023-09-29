using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildController : MonoBehaviour
{
    float speed = -0.2f;
    public bool isFall = true;
    public bool isBeam = false;
    //�|�����Ƃ��̃G�t�F�N�g
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
            //�G�t�F�N�g�𔭐�������
            GenerateEffect();
        }
    }
    //�G�t�F�N�g�𐶐�����
    void GenerateEffect()
    {
        //�G�t�F�N�g�𐶐�����
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //�G�t�F�N�g����������ꏊ�����肷��(�G�I�u�W�F�N�g�̏ꏊ)
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

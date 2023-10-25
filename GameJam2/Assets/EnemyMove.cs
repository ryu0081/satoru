using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //�C���X�y�N�^�[�ŕύX�ł���ϐ�
    [SerializeField]
    [Tooltip("�T���O���[�v")]  //����n�_�����K�v������
    GameObject pointGroup;

    [SerializeField]
    [Tooltip("�͂��߂ɒT������n�_")]
    int destPoint = 0;

    [SerializeField, Range(0, 100)]
    [Tooltip("�T���͈�")]
    float trackingRange = 3.0f;

    [SerializeField, Range(0, 150)]
    [Tooltip("�ǐՔ͈�")]
    float quitRange = 5f;

    [SerializeField, Range(0, 25)]
    [Tooltip("�G�̃X�s�[�h")]
    float speed = 5.0f;

    //�G���ێ����Ă���ϐ�
    private List<Transform> points = new List<Transform>();
    private bool tracking = false;
    private GameObject target;

    // Start is called before the first frame update
    void OnEnable()
    {
        //target�̃Q�[���I�u�W�F�N�g���擾
        target = GameObject.Find("Player");
        //����n�_points�̃��X�g�ɒǉ�
        for (int i = 0; i < pointGroup.transform.childCount; i++)
        {
            points.Add(pointGroup.transform.GetChild(i).gameObject.transform);
            pointGroup.transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = target.transform.position;
        //�G�Ə���n�_�̋������v�Z
        var distanceToTarget = Vector3.Distance(this.transform.position, targetPos);
        //�G�ƃv���C���[�Ƃ̋������v�Z
        var distanceToNextPoint = Vector3.Distance(this.transform.position, points[destPoint].transform.position);
        //�v���C���[�Ƃ̋�����tracking���Ȃ�Βǐ�
        if (tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToTarget;
            if (distanceToTarget > quitRange) tracking = false;
            //�ړ����������s
            this.transform.position = Vector3.Lerp(transform.position, target.transform.position, currentPos);
        }
        //�v���C���[�Ƃ̋�����quitRange�O�Ȃ�ΒT���ɖ߂�
        else if (!tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToNextPoint;
            if (distanceToTarget < trackingRange) tracking = true;
            //����n�_���Ȃ��Ƃ��͏��������Ȃ�
            if (points.Count == 0) return;
            //�ړ����������s
            this.transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, currentPos);
            //���̏���n�_������
            if (currentPos >= 1)
            {
                destPoint = (destPoint + 1) % points.Count;
            }
        }
    }
}

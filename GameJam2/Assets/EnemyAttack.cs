using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 60f;
    private float nextAttackTime = 0f;

    private GameObject player;
    private GameObject building;

    public int damage = 10; // �_���[�W��

    private void Awake()
    {
        // �悭�A�N�Z�X����Q�[���I�u�W�F�N�g�ւ̎Q�Ƃ��L���b�V��
        player = GameObject.FindGameObjectWithTag("Player");
        building = GameObject.FindGameObjectWithTag("building");
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            GameObject target = GetClosestTarget();

            if (target != null && Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                Attack(target);
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }
    }

    GameObject GetClosestTarget()
    {
        float playerDistance = (player != null) ? Vector3.Distance(transform.position, player.transform.position) : float.MaxValue;
        float buildingDistance = (building != null) ? Vector3.Distance(transform.position, building.transform.position) : float.MaxValue;

        // ��苗�����Z���^�[�Q�b�g�i�v���C���[�܂��͌����j��Ԃ�
        return (playerDistance < buildingDistance) ? player : building;
    }

    void Attack(GameObject target)
    {
        // �I�����ꂽ�^�[�Q�b�g�Ƀ_���[�W��^���郍�W�b�N������
        // ��: target.GetComponent<PlayerHealth>().TakeDamage(10);

        Debug.Log("�G��" + target.name + "�ɍU�����܂����I");

        // �^�[�Q�b�g�Ƀ_���[�W��^���郍�W�b�N
        // �R���C�_�[���g�����Փˌ��o
        Collider targetCollider = target.GetComponent<Collider>();

        if (targetCollider != null)
        {
            // �_���[�W��^����
            targetCollider.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }

        // �ŏI�r���h�ł̓f�o�b�O���O���폜�܂��͖��������邱�Ƃ��������Ă�������
        //Debug.Log("���̍U������: " + nextAttackTime);
    }
}

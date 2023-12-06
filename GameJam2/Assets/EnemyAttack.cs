using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 15f;
    private float nextAttackTime = 0f;

    public GameObject[] Attacks;

    private GameObject player;
    private GameObject building;

    private Animator _animator;

    public GameObject satoruSpoon;

    GameObject obj;

    public int damage = 10; // �_���[�W��

    private void Awake()
    {
        // �悭�A�N�Z�X����Q�[���I�u�W�F�N�g�ւ̎Q�Ƃ��L���b�V��
        player = GameObject.FindGameObjectWithTag("Player");
        building = GameObject.FindGameObjectWithTag("building");
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            GameObject target = GetClosestTarget();

            if (target != null && Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                ChooseAttackPattern(target);
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

    void ChooseAttackPattern(GameObject target)
    {
        // �I�����ꂽ�^�[�Q�b�g�Ƀ_���[�W��^���郍�W�b�N������
        // ��: target.GetComponent<PlayerHealth>().TakeDamage(10);
        int randomPattern = Random.Range(1, 4); // 1����3�܂ł̃����_���Ȑ�
        switch (randomPattern)
        {
            case 1:
                AttackPattern1();
                Debug.Log(randomPattern);
                break;
            case 2:
                AttackPattern2();
                Debug.Log(randomPattern);
                break;
            case 3:
                AttackPattern3();
                Debug.Log(randomPattern);
                break;
        }
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

    void AttackPattern1()  //satoru�̍U��
    {
        obj = (GameObject)Instantiate(Attacks[0], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Satoru", true);
        Debug.Log("�G���U�����܂����I");
        StartCoroutine(ResetAnimationBool("Satoru"));
    }
    void AttackPattern2()  //�r�[���̍U��
    {
        obj = (GameObject)Instantiate(Attacks[1], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Attack1", true);
        Debug.Log("�G���U�����܂����I");
        StartCoroutine(ResetAnimationBool("Attack1"));
    }
    void AttackPattern3()  //�z�[�~���O�̍U��
    {
        obj = (GameObject)Instantiate(Attacks[2], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Homing", true);
        Debug.Log("�G���U�����܂����I");
        StartCoroutine(ResetAnimationBool("Homing"));
    }
    public IEnumerator ResetAnimationBool(string paramName)
    {
        // Bool�p�����[�^�����Z�b�g
        _animator.SetBool(paramName, false);

        yield return null;
    }
}

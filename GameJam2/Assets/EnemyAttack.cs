using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;

    public float attackCooldown = 25f;

    private float nextAttackTime = 0f;

    public GameObject[] Attacks;

    private GameObject player;
    private GameObject building;

    private Animator _animator;

    public GameObject satoruSpoon;

    GameObject obj;

    public int damage = 10; // �_���[�W��

    bool eAttack=false;

    int counter;

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
                if (CanAttack())
                {
                    ChooseAttackPattern(target);
                    nextAttackTime = Time.time + 1f / attackCooldown;
                }
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
    bool CanAttack()
    {
        // ���݂̎��Ԃ����̍U�����Ԃ��߂��Ă��邩�ǂ������m�F
        return Time.time >= nextAttackTime;
    }

    void ChooseAttackPattern(GameObject target)
    {
        // �I�����ꂽ�^�[�Q�b�g�Ƀ_���[�W��^���郍�W�b�N������
        // ��: target.GetComponent<PlayerHealth>().TakeDamage(10);
        int randomPattern = Random.Range(1, 4); // 1����3�܂ł̃����_���Ȑ�

        if (CanAttack())
        {
            switch (randomPattern)
            {

                case 1:
                    eAttack = true;
                    AttackPattern1();
                    Debug.Log(randomPattern);
                    break;

                case 2:
                    eAttack = true;
                    AttackPattern2();
                    Debug.Log(randomPattern);

                    break;

                case 3:
                    eAttack = true;
                    AttackPattern3();
                    Debug.Log(randomPattern);
                    break;
            }
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
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[0], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent=gameObject.transform;
        _animator.SetTrigger("1");
        if(counter == 10) 
        {
            eAttack = false;
        }

        
        Debug.Log("�G���U�����܂����I");
       
    }

    void AttackPattern2()  //�r�[���̍U��
    {
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[1], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent = gameObject.transform;
        _animator.SetTrigger("2");
        
        if (counter == 10)
        {
            eAttack = false;
        }
        Debug.Log("�G���U�����܂����I");
        //StartCoroutine(ResetAnimationBool("2"));
    }

    void AttackPattern3()  //�z�[�~���O�̍U��
    {
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[2], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent = gameObject.transform;
        _animator.SetTrigger("3");
        if (counter == 10)
        {
            eAttack = false;
        }
        Debug.Log("�G���U�����܂����I");
        //StartCoroutine(ResetAnimationBool("3"));
    }
    public IEnumerator ResetAnimationBool(string paramName)
    {
        // Bool�p�����[�^�����Z�b�g
        _animator.SetTrigger(paramName);

        yield return null;
    }
}

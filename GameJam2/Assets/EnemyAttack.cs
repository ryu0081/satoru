using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 10;
    public float attackCooldown = 60f; // �U���̃N�[���_�E������
    private float nextAttackTime = 0f;

    //public float timeBetweenAttacks = 0.5f;  //�U����

    //public int attackDamage = 10;      //�_���[�W 10�͉�

    //private GameObject player;�@�@�@//�v���C���[���ʗp
    //private bool playerInRange;     //�v���C���[�ɂ��Ă�͈�
    //private float timer;�@�@�@�@�@�@//�N�[���^�C��

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");   //�^�O�u�v���C���[�v�����m����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �N�[���_�E�����I�����Ă���A�v���C���[���U���͈͓��ɂ��邩�ǂ������m�F
        if (Time.time >= nextAttackTime)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null && Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                // �U�����J�n
                Attack();

                // ���̍U���̃N�[���_�E�����Ԃ�ݒ�
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }
        //timer += Time.deltaTime;�@�@�@�@

        //if (timer >= timeBetweenAttacks && playerInRange)
        //{
        //    Attack();�@�@�@�@�@//�N�[���^�C�����J���Ă邩�v���C���[���͈͓��Ȃ�U��
        //    //�U���̃A�j���[�V����������Ȃ炱��

        //}
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = true;      //�U���͈͂ɂ��邩�ǂ����̃t���O
    //        Debug.Log("�U��");
    //    }
    //}

    //void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = false;
    //    }
    //}
    //void Attack()
    //{
    //    timer = 0f;

    //    // Insert player health deduction logic here
    //    // Example: playerHealth.TakeDamage(attackDamage);
    //}
    void Attack()
    {
        //// �v���C���[�Ƀ_���[�W��^����Ȃǂ̃A�N�V���������s
        //Player.TakeDamage(damage);
        // �v���C���[�Ƀ_���[�W��^����Ȃǂ̃A�N�V���������s
        // ���̕����́A�v���C���[�Ƀ_���[�W��^����֐��ɒu��������K�v������܂�
        Debug.Log("Player Attacked!");

        // �N�[���_�E�����ݒ肳��Ă��邩�m�F
        Debug.Log("Next Attack Time: " + nextAttackTime);
    }
}

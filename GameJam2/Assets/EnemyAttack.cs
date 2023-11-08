using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;  //�U����

    public int attackDamage = 10;      //�_���[�W 10�͉�

    private GameObject player;�@�@�@//�v���C���[���ʗp
    private bool playerInRange;     //�v���C���[�ɂ��Ă�͈�
    private float timer;�@�@�@�@�@�@//�N�[���^�C��

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");   //�^�O�u�v���C���[�v�����m����
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;�@�@�@�@

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();�@�@�@�@�@//�N�[���^�C�����J���Ă邩�v���C���[���͈͓��Ȃ�U��
            //�U���̃A�j���[�V����������Ȃ炱��
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;      //�U���͈͂ɂ��邩�ǂ����̃t���O
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }
    void Attack()
    {
        timer = 0f;

        // Insert player health deduction logic here
        // Example: playerHealth.TakeDamage(attackDamage);
    }
}

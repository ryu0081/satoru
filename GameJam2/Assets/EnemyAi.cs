using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;  //�v���C���[�̕ϊ��p�֐�

    public LayerMask whatIsGround, whatIsPlayer;   //����p�̒n�ʂƃv���C���[�̃��C���[�}�X�N

    //�p�g���[���p
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;    //�s���͈͂𐧌䂷��

    //�U���p
    public float timeBetweenAttacks;
    bool alreadyAttacked;      //�U���������ǂ���

    //�U���͈͗p
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAtteckRange;  //�U���͈͓��ɂ��邩�ǂ���


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

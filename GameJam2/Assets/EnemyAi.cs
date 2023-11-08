using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;  //�v���C���[�̕ϊ��p�֐�

    public LayerMask whatIsGround, whatIsPlayer;   //����p�̒n�ʂƃv���C���[�̃��C���[�}�X�N

    public float health;

    //�p�g���[���p
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;    //�s���͈͂𐧌䂷��

    //�U���p
    public float timeBetweenAttacks;
    bool alreadyAttacked;      //�U���������ǂ���
    public GameObject projectile;

    //�U���͈͗p
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAtteckRange;  //�U���͈͓��ɂ��邩�ǂ���

    private void Awake()
    {
        player = GameObject.Find("Player").transform;    //Player���Ō���
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    private void Update()
    {
        //���E���ɂ��邩�A�U���͈͓��ɂ��邩�ǂ���
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAtteckRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAtteckRange) Patroling();  //�v���C���[�����E���ɂ��U���͈͓��ɂ����Ȃ����́A����
        if (playerInSightRange && !playerInAtteckRange) ChasePlayer(); //���E���ɂ͂��邪�A�U���͈͓��ɂ��Ȃ��ꍇ�͒ǐՂ���
        if (playerInSightRange && playerInAtteckRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWarkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;  //WalkPoint�܂ł̋������w��

        //������1�����̏ꍇ
        if (distanceToWalkPoint.magnitude < 1f) 
            walkPointSet = false;

    }

    private void SearchWarkPoint()
    {
        //�͈͓��̃����_���|�C���g���v�Z����
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 5f, whatIsGround)) 
            walkPointSet= true;

    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //�G�������Ȃ��悤�ɂ���
        agent.SetDestination(transform.position);

        transform.LookAt(player);   //�v���C���[������

        if (!alreadyAttacked)     //�U���������ǂ����𔻒f
        {
            ///Attack code here
            Rigidbody rb=Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            alreadyAttacked = true;
            //�U���Ԃ̎��Ԃ����Z�b�g�U���֐����̒x���Ƃ���
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        //���Z�b�g�U���֐�
        alreadyAttacked= false;
    }

    //�G�ւ̃_���[�W�Ǘ�
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
            Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

   
}

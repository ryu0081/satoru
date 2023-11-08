using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;  //プレイヤーの変換用関数

    public LayerMask whatIsGround, whatIsPlayer;   //巡回用の地面とプレイヤーのレイヤーマスク

    public float health;

    //パトロール用
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;    //行動範囲を制御する

    //攻撃用
    public float timeBetweenAttacks;
    bool alreadyAttacked;      //攻撃したかどうか
    public GameObject projectile;

    //攻撃範囲用
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAtteckRange;  //攻撃範囲内にいるかどうか

    private void Awake()
    {
        player = GameObject.Find("Player").transform;    //Player名で検索
        agent = GetComponent<NavMeshAgent>();
    }
    // Update is called once per frame
    private void Update()
    {
        //視界内にあるか、攻撃範囲内にいるかどうか
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAtteckRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAtteckRange) Patroling();  //プレイヤーが視界内にも攻撃範囲内にもいない時は、巡回
        if (playerInSightRange && !playerInAtteckRange) ChasePlayer(); //視界内にはいるが、攻撃範囲内にいない場合は追跡する
        if (playerInSightRange && playerInAtteckRange) AttackPlayer();

    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWarkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;  //WalkPointまでの距離を指定

        //距離が1未満の場合
        if (distanceToWalkPoint.magnitude < 1f) 
            walkPointSet = false;

    }

    private void SearchWarkPoint()
    {
        //範囲内のランダムポイントを計算する
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
        //敵が動かないようにする
        agent.SetDestination(transform.position);

        transform.LookAt(player);   //プレイヤーを見る

        if (!alreadyAttacked)     //攻撃したかどうかを判断
        {
            ///Attack code here
            Rigidbody rb=Instantiate(projectile,transform.position, Quaternion.identity).GetComponent<Rigidbody>();

            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);


            alreadyAttacked = true;
            //攻撃間の時間をリセット攻撃関数内の遅延とする
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }

    }

    private void ResetAttack()
    {
        //リセット攻撃関数
        alreadyAttacked= false;
    }

    //敵へのダメージ管理
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

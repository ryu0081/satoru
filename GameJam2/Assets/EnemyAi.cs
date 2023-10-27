using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;  //プレイヤーの変換用関数

    public LayerMask whatIsGround, whatIsPlayer;   //巡回用の地面とプレイヤーのレイヤーマスク

    //パトロール用
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;    //行動範囲を制御する

    //攻撃用
    public float timeBetweenAttacks;
    bool alreadyAttacked;      //攻撃したかどうか

    //攻撃範囲用
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAtteckRange;  //攻撃範囲内にいるかどうか


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

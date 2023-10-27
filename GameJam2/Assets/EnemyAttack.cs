using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public float timeBetweenAttacks = 0.5f;  //攻撃間

    public int attackDamage = 10;      //ダメージ 10は仮

    private GameObject player;　　　//プレイヤー判別用
    private bool playerInRange;     //プレイヤーにあてる範囲
    private float timer;　　　　　　//クールタイム

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");   //タグ「プレイヤー」を感知する
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;　　　　

        if (timer >= timeBetweenAttacks && playerInRange)
        {
            Attack();　　　　　//クールタイムが開けてるかつプレイヤーが範囲内なら攻撃
            //攻撃のアニメーションを入れるならここ
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            playerInRange = true;      //攻撃範囲にいるかどうかのフラグ
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

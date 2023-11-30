using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public int damage = 10;
    public float attackCooldown = 60f; // 攻撃のクールダウン時間
    private float nextAttackTime = 0f;

    //public float timeBetweenAttacks = 0.5f;  //攻撃間

    //public int attackDamage = 10;      //ダメージ 10は仮

    //private GameObject player;　　　//プレイヤー判別用
    //private bool playerInRange;     //プレイヤーにあてる範囲
    //private float timer;　　　　　　//クールタイム

    private void Awake()
    {
        //player = GameObject.FindGameObjectWithTag("Player");   //タグ「プレイヤー」を感知する
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // クールダウンが終了しており、プレイヤーが攻撃範囲内にいるかどうかを確認
        if (Time.time >= nextAttackTime)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            if (player != null && Vector3.Distance(transform.position, player.transform.position) < attackRange)
            {
                // 攻撃を開始
                Attack();

                // 次の攻撃のクールダウン時間を設定
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }
        //timer += Time.deltaTime;　　　　

        //if (timer >= timeBetweenAttacks && playerInRange)
        //{
        //    Attack();　　　　　//クールタイムが開けてるかつプレイヤーが範囲内なら攻撃
        //    //攻撃のアニメーションを入れるならここ

        //}
    }
    //void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject == player)
    //    {
    //        playerInRange = true;      //攻撃範囲にいるかどうかのフラグ
    //        Debug.Log("攻撃");
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
        //// プレイヤーにダメージを与えるなどのアクションを実行
        //Player.TakeDamage(damage);
        // プレイヤーにダメージを与えるなどのアクションを実行
        // この部分は、プレイヤーにダメージを与える関数に置き換える必要があります
        Debug.Log("Player Attacked!");

        // クールダウンが設定されているか確認
        Debug.Log("Next Attack Time: " + nextAttackTime);
    }
}

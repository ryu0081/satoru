using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 60f;
    private float nextAttackTime = 0f;

    private GameObject player;
    private GameObject building;

    public int damage = 10; // ダメージ量

    private void Awake()
    {
        // よくアクセスするゲームオブジェクトへの参照をキャッシュ
        player = GameObject.FindGameObjectWithTag("Player");
        building = GameObject.FindGameObjectWithTag("building");
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            GameObject target = GetClosestTarget();

            if (target != null && Vector3.Distance(transform.position, target.transform.position) < attackRange)
            {
                Attack(target);
                nextAttackTime = Time.time + 1f / attackCooldown;
            }
        }
    }

    GameObject GetClosestTarget()
    {
        float playerDistance = (player != null) ? Vector3.Distance(transform.position, player.transform.position) : float.MaxValue;
        float buildingDistance = (building != null) ? Vector3.Distance(transform.position, building.transform.position) : float.MaxValue;

        // より距離が短いターゲット（プレイヤーまたは建物）を返す
        return (playerDistance < buildingDistance) ? player : building;
    }

    void Attack(GameObject target)
    {
        // 選択されたターゲットにダメージを与えるロジックを実装
        // 例: target.GetComponent<PlayerHealth>().TakeDamage(10);

        Debug.Log("敵が" + target.name + "に攻撃しました！");

        // ターゲットにダメージを与えるロジック
        // コライダーを使った衝突検出
        Collider targetCollider = target.GetComponent<Collider>();

        if (targetCollider != null)
        {
            // ダメージを与える
            targetCollider.gameObject.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        }

        // 最終ビルドではデバッグログを削除または無効化することを検討してください
        //Debug.Log("次の攻撃時間: " + nextAttackTime);
    }
}

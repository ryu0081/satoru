using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;
    public float attackCooldown = 15f;
    private float nextAttackTime = 0f;

    public GameObject[] Attacks;

    private GameObject player;
    private GameObject building;

    private Animator _animator;

    public GameObject satoruSpoon;

    GameObject obj;

    public int damage = 10; // ダメージ量

    private void Awake()
    {
        // よくアクセスするゲームオブジェクトへの参照をキャッシュ
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
                ChooseAttackPattern(target);
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

    void ChooseAttackPattern(GameObject target)
    {
        // 選択されたターゲットにダメージを与えるロジックを実装
        // 例: target.GetComponent<PlayerHealth>().TakeDamage(10);
        int randomPattern = Random.Range(1, 4); // 1から3までのランダムな数
        switch (randomPattern)
        {
            case 1:
                AttackPattern1();
                Debug.Log(randomPattern);
                break;
            case 2:
                AttackPattern2();
                Debug.Log(randomPattern);
                break;
            case 3:
                AttackPattern3();
                Debug.Log(randomPattern);
                break;
        }
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

    void AttackPattern1()  //satoruの攻撃
    {
        obj = (GameObject)Instantiate(Attacks[0], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Satoru", true);
        Debug.Log("敵が攻撃しました！");
        StartCoroutine(ResetAnimationBool("Satoru"));
    }
    void AttackPattern2()  //ビームの攻撃
    {
        obj = (GameObject)Instantiate(Attacks[1], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Attack1", true);
        Debug.Log("敵が攻撃しました！");
        StartCoroutine(ResetAnimationBool("Attack1"));
    }
    void AttackPattern3()  //ホーミングの攻撃
    {
        obj = (GameObject)Instantiate(Attacks[2], satoruSpoon.transform.position, transform.rotation);
        _animator.SetBool("Homing", true);
        Debug.Log("敵が攻撃しました！");
        StartCoroutine(ResetAnimationBool("Homing"));
    }
    public IEnumerator ResetAnimationBool(string paramName)
    {
        // Boolパラメータをリセット
        _animator.SetBool(paramName, false);

        yield return null;
    }
}

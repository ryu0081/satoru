using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 2f;

    public float attackCooldown = 25f;

    private float nextAttackTime = 0f;

    public GameObject[] Attacks;

    private GameObject player;
    private GameObject building;

    private Animator _animator;

    public GameObject satoruSpoon;

    GameObject obj;

    public int damage = 10; // ダメージ量

    bool eAttack=false;

    int counter;

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
                if (CanAttack())
                {
                    ChooseAttackPattern(target);
                    nextAttackTime = Time.time + 1f / attackCooldown;
                }
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
    bool CanAttack()
    {
        // 現在の時間が次の攻撃時間を過ぎているかどうかを確認
        return Time.time >= nextAttackTime;
    }

    void ChooseAttackPattern(GameObject target)
    {
        // 選択されたターゲットにダメージを与えるロジックを実装
        // 例: target.GetComponent<PlayerHealth>().TakeDamage(10);
        int randomPattern = Random.Range(1, 4); // 1から3までのランダムな数

        if (CanAttack())
        {
            switch (randomPattern)
            {

                case 1:
                    eAttack = true;
                    AttackPattern1();
                    Debug.Log(randomPattern);
                    break;

                case 2:
                    eAttack = true;
                    AttackPattern2();
                    Debug.Log(randomPattern);

                    break;

                case 3:
                    eAttack = true;
                    AttackPattern3();
                    Debug.Log(randomPattern);
                    break;
            }
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
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[0], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent=gameObject.transform;
        _animator.SetTrigger("1");
        if(counter == 10) 
        {
            eAttack = false;
        }

        
        Debug.Log("敵が攻撃しました！");
       
    }

    void AttackPattern2()  //ビームの攻撃
    {
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[1], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent = gameObject.transform;
        _animator.SetTrigger("2");
        
        if (counter == 10)
        {
            eAttack = false;
        }
        Debug.Log("敵が攻撃しました！");
        //StartCoroutine(ResetAnimationBool("2"));
    }

    void AttackPattern3()  //ホーミングの攻撃
    {
        counter++;
        eAttack = true;
        obj = (GameObject)Instantiate(Attacks[2], satoruSpoon.transform.position, transform.rotation);
        this.obj.transform.parent = gameObject.transform;
        _animator.SetTrigger("3");
        if (counter == 10)
        {
            eAttack = false;
        }
        Debug.Log("敵が攻撃しました！");
        //StartCoroutine(ResetAnimationBool("3"));
    }
    public IEnumerator ResetAnimationBool(string paramName)
    {
        // Boolパラメータをリセット
        _animator.SetTrigger(paramName);

        yield return null;
    }
}

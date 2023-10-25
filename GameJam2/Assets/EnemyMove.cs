using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    //インスペクターで変更できる変数
    [SerializeField]
    [Tooltip("探索グループ")]  //巡回地点を作る必要がある
    GameObject pointGroup;

    [SerializeField]
    [Tooltip("はじめに探索する地点")]
    int destPoint = 0;

    [SerializeField, Range(0, 100)]
    [Tooltip("探索範囲")]
    float trackingRange = 3.0f;

    [SerializeField, Range(0, 150)]
    [Tooltip("追跡範囲")]
    float quitRange = 5f;

    [SerializeField, Range(0, 25)]
    [Tooltip("敵のスピード")]
    float speed = 5.0f;

    //敵が保持している変数
    private List<Transform> points = new List<Transform>();
    private bool tracking = false;
    private GameObject target;

    // Start is called before the first frame update
    void OnEnable()
    {
        //targetのゲームオブジェクトを取得
        target = GameObject.Find("Player");
        //巡回地点pointsのリストに追加
        for (int i = 0; i < pointGroup.transform.childCount; i++)
        {
            points.Add(pointGroup.transform.GetChild(i).gameObject.transform);
            pointGroup.transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        var targetPos = target.transform.position;
        //敵と巡回地点の距離を計算
        var distanceToTarget = Vector3.Distance(this.transform.position, targetPos);
        //敵とプレイヤーとの距離を計算
        var distanceToNextPoint = Vector3.Distance(this.transform.position, points[destPoint].transform.position);
        //プレイヤーとの距離がtracking内ならば追跡
        if (tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToTarget;
            if (distanceToTarget > quitRange) tracking = false;
            //移動処理を実行
            this.transform.position = Vector3.Lerp(transform.position, target.transform.position, currentPos);
        }
        //プレイヤーとの距離がquitRange外ならば探索に戻る
        else if (!tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToNextPoint;
            if (distanceToTarget < trackingRange) tracking = true;
            //巡回地点がないときは処理をしない
            if (points.Count == 0) return;
            //移動処理を実行
            this.transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, currentPos);
            //次の巡回地点を決定
            if (currentPos >= 1)
            {
                destPoint = (destPoint + 1) % points.Count;
            }
        }
    }
}

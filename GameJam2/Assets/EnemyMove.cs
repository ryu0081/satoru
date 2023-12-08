using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class EnemyMove : MonoBehaviour
{
    //インスペクターで変更できる変数
    [SerializeField]
    [Tooltip("探索グループ")]  //巡回地点を作る必要がある
    GameObject pointGroup;

    [SerializeField]
    NavMeshAgent navmeshAgent = null;

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

    private float _animationBlend;

    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.28f;
    public LayerMask GroundLayers;
    public bool Grounded = true;

    private bool _hasAnimator;
    //敵が保持している変数
    private List<Transform> points = new List<Transform>();
    private CharacterController _controller;
    private bool tracking = false;
    private GameObject target;

    private Animator _animator;
    // アニメーター
    //private Animator m_Animator = null;

    float speedx;
    float speedy;

    // アニメーションID
    private int _animIDSpeed;
    private int _animIDGrounded;

    // Start is called before the first frame update
    void OnEnable()
    {
        ////targetのゲームオブジェクトを取得
        target = GameObject.FindGameObjectWithTag("Player");

        //m_Animator = GetComponent<Animator>();

        //巡回地点pointsのリストに追加
        for (int i = 0; i < pointGroup.transform.childCount; i++)
        {
            points.Add(pointGroup.transform.GetChild(i).gameObject.transform);
            pointGroup.transform.GetChild(i).GetComponent<Renderer>().material.color = new Color(0, 0, 0, 0);
        }
    }
    private void Start()
    {
        _controller = GetComponent<CharacterController>();
        _hasAnimator = TryGetComponent(out _animator);
        //AssignAnimationIDs();
    }


    private void AssignAnimationIDs()
    {
        _animIDSpeed = Animator.StringToHash("Speed");
        _animIDGrounded = Animator.StringToHash("Grounded");
    }
    private void GroundedCheck()
    {
        // オフセットを使用して球の位置を設定します
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        // キャラクターを使用している場合はアニメーターを更新する
        if (_hasAnimator)
        {
            _animator.SetBool(_animIDGrounded, Grounded);
        }
    }
    // Update is called once per frame
    void Update()
        {
        navmeshAgent.SetDestination(target.transform.position);
        var targetPos = target.transform.position;
        //敵と巡回地点の距離を計算
        var distanceToTarget = Vector3.Distance(this.transform.position, targetPos);
        //敵とプレイヤーとの距離を計算
        var distanceToNextPoint = Vector3.Distance(this.transform.position, points[destPoint].transform.position);

        GroundedCheck();

        //プレイヤーとの距離がtracking内ならば追跡
        if (!CheckForObstacles())//tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToTarget;
            if (distanceToTarget > quitRange) tracking = false;
            //移動処理を実行
            this.transform.position = Vector3.Lerp(transform.position, target.transform.position, currentPos);
            if (_hasAnimator)
            {

                //_animIDSpeed += 1;
                _animator.SetFloat("Speed", navmeshAgent.desiredVelocity.magnitude);
            }


        }
        //プレイヤーとの距離がquitRange外ならば探索に戻る
        else if (!tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToNextPoint;
            if (distanceToTarget < trackingRange) tracking = true;
            //巡回地点がないときは処理をしない
            if (points.Count == 0) return;

            if (!CheckForObstacles())
            {
                //移動処理を実行
                this.transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, currentPos);
                if (_hasAnimator)
                {
                    //_animIDSpeed += 1;
                    _animator.SetFloat("Speed", navmeshAgent.desiredVelocity.magnitude);
                }
                //次の巡回地点を決定
                if (currentPos >= 1)
                {

                    destPoint = (destPoint + 1) % points.Count;
                }
            }
        
        }
    }
    bool CheckForObstacles()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1.0f, LayerMask.GetMask("Obstacle")))
        {
            return true; // Obstacle detected
        }
        return false; // No obstacle
    }
}

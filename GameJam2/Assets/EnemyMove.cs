using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.XR;

public class EnemyMove : MonoBehaviour
{
    //�C���X�y�N�^�[�ŕύX�ł���ϐ�
    [SerializeField]
    [Tooltip("�T���O���[�v")]  //����n�_�����K�v������
    GameObject pointGroup;

    [SerializeField]
    NavMeshAgent navmeshAgent = null;

    [SerializeField]
    [Tooltip("�͂��߂ɒT������n�_")]
    int destPoint = 0;

    [SerializeField, Range(0, 100)]
    [Tooltip("�T���͈�")]
    float trackingRange = 3.0f;

    [SerializeField, Range(0, 150)]
    [Tooltip("�ǐՔ͈�")]
    float quitRange = 5f;

    [SerializeField, Range(0, 25)]
    [Tooltip("�G�̃X�s�[�h")]
    float speed = 5.0f;

    private float _animationBlend;

    public float GroundedOffset = -0.14f;
    public float GroundedRadius = 0.28f;
    public LayerMask GroundLayers;
    public bool Grounded = true;

    private bool _hasAnimator;
    //�G���ێ����Ă���ϐ�
    private List<Transform> points = new List<Transform>();
    private CharacterController _controller;
    private bool tracking = false;
    private GameObject target;

    private Animator _animator;
    // �A�j���[�^�[
    //private Animator m_Animator = null;

    float speedx;
    float speedy;

    // �A�j���[�V����ID
    private int _animIDSpeed;
    private int _animIDGrounded;

    // Start is called before the first frame update
    void OnEnable()
    {
        ////target�̃Q�[���I�u�W�F�N�g���擾
        target = GameObject.FindGameObjectWithTag("Player");

        //m_Animator = GetComponent<Animator>();

        //����n�_points�̃��X�g�ɒǉ�
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
        // �I�t�Z�b�g���g�p���ċ��̈ʒu��ݒ肵�܂�
        Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
            transform.position.z);
        Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
            QueryTriggerInteraction.Ignore);

        // �L�����N�^�[���g�p���Ă���ꍇ�̓A�j���[�^�[���X�V����
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
        //�G�Ə���n�_�̋������v�Z
        var distanceToTarget = Vector3.Distance(this.transform.position, targetPos);
        //�G�ƃv���C���[�Ƃ̋������v�Z
        var distanceToNextPoint = Vector3.Distance(this.transform.position, points[destPoint].transform.position);

        GroundedCheck();

        //�v���C���[�Ƃ̋�����tracking���Ȃ�Βǐ�
        if (!CheckForObstacles())//tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToTarget;
            if (distanceToTarget > quitRange) tracking = false;
            //�ړ����������s
            this.transform.position = Vector3.Lerp(transform.position, target.transform.position, currentPos);
            if (_hasAnimator)
            {

                //_animIDSpeed += 1;
                _animator.SetFloat("Speed", navmeshAgent.desiredVelocity.magnitude);
            }


        }
        //�v���C���[�Ƃ̋�����quitRange�O�Ȃ�ΒT���ɖ߂�
        else if (!tracking)
        {
            var currentPos = Time.deltaTime * speed / distanceToNextPoint;
            if (distanceToTarget < trackingRange) tracking = true;
            //����n�_���Ȃ��Ƃ��͏��������Ȃ�
            if (points.Count == 0) return;

            if (!CheckForObstacles())
            {
                //�ړ����������s
                this.transform.position = Vector3.Lerp(transform.position, points[destPoint].transform.position, currentPos);
                if (_hasAnimator)
                {
                    //_animIDSpeed += 1;
                    _animator.SetFloat("Speed", navmeshAgent.desiredVelocity.magnitude);
                }
                //���̏���n�_������
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

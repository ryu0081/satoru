using UnityEngine;
#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

#endif

/*注: アニメーションは、アニメーターの null チェックを使用して、キャラクターとカプセルの両方のコントローラー経由で呼び出されます。
 */

namespace StarterAssets
{
    [RequireComponent(typeof(CharacterController))]
#if ENABLE_INPUT_SYSTEM 
    [RequireComponent(typeof(PlayerInput))]
#endif
    public class ThirdPersonController : MonoBehaviour
    {
        [Header("Player")]
        [Tooltip("Move speed of the character in m/s")]
        public float MoveSpeed = 2.0f;

        [Tooltip("Sprint speed of the character in m/s")]
        public float SprintSpeed = 5.335f;

        [Tooltip("How fast the character turns to face movement direction")]
        [Range(0.0f, 0.3f)]
        public float RotationSmoothTime = 0.12f;

        [Tooltip("Acceleration and deceleration")]
        public float SpeedChangeRate = 10.0f;

        public AudioClip LandingAudioClip;
        public AudioClip[] FootstepAudioClips;
        [Range(0, 1)] public float FootstepAudioVolume = 0.5f;

        [Space(10)]
        [Tooltip("The height the player can jump")]
        public float JumpHeight = 1.2f;

        [Tooltip("The character uses its own gravity value. The engine default is -9.81f")]
        public float Gravity = -15.0f;

        [Space(10)]
        [Tooltip("Time required to pass before being able to jump again. Set to 0f to instantly jump again")]
        public float JumpTimeout = 0.50f;

        [Tooltip("Time required to pass before entering the fall state. Useful for walking down stairs")]
        public float FallTimeout = 0.15f;

        [Header("Player Grounded")]
        //キャラクターが接地しているかどうか。 CharacterController の組み込み接地チェックの一部ではありません
        [Tooltip("If the character is grounded or not. Not part of the CharacterController built in grounded check")]
        public bool Grounded = true;

        [Tooltip("Useful for rough ground")]
        public float GroundedOffset = -0.14f;

        [Tooltip("The radius of the grounded check. Should match the radius of the CharacterController")]
        public float GroundedRadius = 0.28f;

        [Tooltip("What layers the character uses as ground")]
        public LayerMask GroundLayers;

        [Header("Cinemachine")]
        [Tooltip("The follow target set in the Cinemachine Virtual Camera that the camera will follow")]
        public GameObject CinemachineCameraTarget;

        [Tooltip("How far in degrees can you move the camera up")]
        public float TopClamp = 70.0f;

        [Tooltip("How far in degrees can you move the camera down")]
        public float BottomClamp = -30.0f;

        [Tooltip("Additional degress to override the camera. Useful for fine tuning camera position when locked")]
        public float CameraAngleOverride = 0.0f;

        //全軸のカメラ位置をロックする場合
        [Tooltip("For locking the camera position on all axis")]
        public bool LockCameraPosition = false;

        // シネママシン
        private float _cinemachineTargetYaw;
        private float _cinemachineTargetPitch;

        // プレイヤー
        private float _speed;
        private float _animationBlend;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;

        // タイムアウトデルタ時間
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;

        // アニメーションID
        private int _animIDSpeed;
        private int _animIDGrounded;
        private int _animIDJump;
        private int _animIDFreeFall;
        private int _animIDMotionSpeed;

#if ENABLE_INPUT_SYSTEM 
        private PlayerInput _playerInput;
#endif
        private Animator _animator;
        private CharacterController _controller;
        private StarterAssetsInputs _input;
        private GameObject _mainCamera;

        private const float _threshold = 0.01f;

        private bool _hasAnimator;
        public GameObject[] satoruEfect;
        public GameObject satoruSpoon;

        GameObject obj;
        bool satobe ;
        bool jyakube;
        bool homingbe;
        bool cameraON;
        float satorucooltime;
        float jyakucooltime;
        float homicooltime;
        int efectnunber=0;

        private bool IsCurrentDeviceMouse
        {
            get
            {
#if ENABLE_INPUT_SYSTEM
                return _playerInput.currentControlScheme == "KeyboardMouse";
#else
				return false;
#endif
            }
        }


        private void Awake()
        {
            // メインカメラへの参照を取得します
            if (_mainCamera == null)
            {
                _mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
            }
        }

        private void Start()
        {
            _cinemachineTargetYaw = CinemachineCameraTarget.transform.rotation.eulerAngles.y;

            _hasAnimator = TryGetComponent(out _animator);
            _controller = GetComponent<CharacterController>();
            _input = GetComponent<StarterAssetsInputs>();
#if ENABLE_INPUT_SYSTEM 
            _playerInput = GetComponent<PlayerInput>();
#else
			Debug.LogError( "Starter Assets package is missing dependencies. Please use Tools/Starter Assets/Reinstall Dependencies to fix it");
#endif

            AssignAnimationIDs();

            // 開始時にタイムアウトをリセットする
            _jumpTimeoutDelta = JumpTimeout;
            _fallTimeoutDelta = FallTimeout;
        }

        private void Update()
        {
            satobe = camerasystem.satobe;
            jyakube = camerasystem.jyakube;
            homingbe = camerasystem.homingbe;
            cameraON = camerasystem.cameraON;
            _hasAnimator = TryGetComponent(out _animator);
            //Attack();
            JumpAndGravity();
            GroundedCheck();
            if(cameraON)
            {
                Move();
            }
            
        }

        private void LateUpdate()
        {
            if(cameraON)
            {
                CameraRotation();
            }
            
        }

        private void AssignAnimationIDs()
        {
            _animIDSpeed = Animator.StringToHash("Speed");
            _animIDGrounded = Animator.StringToHash("Grounded");
            _animIDJump = Animator.StringToHash("Jump");
            _animIDFreeFall = Animator.StringToHash("FreeFall");
            _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");
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

        private void CameraRotation()
        {
            // 入力があり、カメラの位置が固定されていない場合
            if (_input.look.sqrMagnitude >= _threshold && !LockCameraPosition)
            {
                //マウス入力に Time.deltaTime を掛けないでください。
                float deltaTimeMultiplier = IsCurrentDeviceMouse ? 1.0f : Time.deltaTime;

                _cinemachineTargetYaw += _input.look.x * deltaTimeMultiplier;
                _cinemachineTargetPitch += _input.look.y * deltaTimeMultiplier;
            }

            // 回転をクランプして、値を 360 度に制限します。
            _cinemachineTargetYaw = ClampAngle(_cinemachineTargetYaw, float.MinValue, float.MaxValue);
            _cinemachineTargetPitch = ClampAngle(_cinemachineTargetPitch, BottomClamp, TopClamp);

            // Cinemachine はこの目標に従います
            CinemachineCameraTarget.transform.rotation = Quaternion.Euler(_cinemachineTargetPitch + CameraAngleOverride,
                _cinemachineTargetYaw, 0.0f);
        }

        private void Move()
        {
            // 移動速度、スプリント速度、およびスプリントが押されたかどうかに基づいて目標速度を設定します
            float targetSpeed = _input.sprint ? SprintSpeed : MoveSpeed;

            // 簡単に削除、交換、または反復できるように設計された単純化された加速と減速

            // 注: Vector2 の == 演算子は近似を使用するため、浮動小数点エラーが発生しにくく、大きさよりもコストがかかりません。
            // 入力がない場合は、目標速度を 0 に設定します。
            if (_input.move == Vector2.zero) targetSpeed = 0.0f;

            // プレイヤーの現在の水平速度への参照
            float currentHorizontalSpeed = new Vector3(_controller.velocity.x, 0.0f, _controller.velocity.z).magnitude;

            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // 目標速度まで加速または減速する
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // 直線的な結果ではなく曲線的な結果が生成され、より有機的な速度変化が得られます。
                // Lerp の T はクランプされているので、速度をクランプする必要がないことに注意してください。
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * SpeedChangeRate);

                // 小数点以下 3 桁までの丸め速度
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * SpeedChangeRate);
            if (_animationBlend < 0.01f) _animationBlend = 0f;

            // 入力方向を正規化する
            Vector3 inputDirection = new Vector3(_input.move.x, 0.0f, _input.move.y).normalized;

            // 注: Vector2 の != 演算子は近似を使用するため、浮動小数点エラーが発生しにくく、大きさよりもコストがかかりません。
            // 移動入力がある場合、プレーヤーが移動しているときにプレーヤーを回転します
            if (_input.move != Vector2.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // カメラ位置を基準にして入力方向を向くように回転します
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }


            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            //プレーヤーを動かす
            _controller.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

            // キャラクターを使用している場合はアニメーターを更新する
            if (_hasAnimator)
            {
                _animator.SetFloat(_animIDSpeed, _animationBlend);
                _animator.SetFloat(_animIDMotionSpeed, inputMagnitude);
            }
        }

        private void JumpAndGravity()
        {
            if (Grounded)
            {
                // フォールタイムアウトタイマーをリセットする
                _fallTimeoutDelta = FallTimeout;

                // キャラクターを使用している場合はアニメーターを更新する
                if (_hasAnimator)
                {
                    _animator.SetBool(_animIDJump, false);
                    _animator.SetBool(_animIDFreeFall, false);
                }

                // 接地時に速度が無限に低下するのを阻止する
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // ジャンプ
                if (_input.jump && _jumpTimeoutDelta <= 0.0f)
                {
                    // JumpHeight * -2f * Gravity = 希望の高さに到達するために必要な速度
                    _verticalVelocity = Mathf.Sqrt(JumpHeight * -2f * Gravity);

                    // キャラクターを使用している場合はアニメーターを更新する
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDJump, true);
                    }
                }

                // ジャンプタイムアウト
                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else
            {
                // ジャンプタイムアウトタイマーをリセットする
                _jumpTimeoutDelta = JumpTimeout;

                // フォールタイムアウト
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
                else
                {
                    // キャラクターを使用している場合はアニメーターを更新する
                    if (_hasAnimator)
                    {
                        _animator.SetBool(_animIDFreeFall, true);
                    }
                }

                // 接地していない場合は、ジャンプしないでください
                _input.jump = false;
            }

            // ターミナルの下にある場合は、時間の経過とともに重力を適用します (時間の経過とともに直線的に速度を上げるには、デルタ時間を 2 回乗算します)
            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * Time.deltaTime;
            }
        }

        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }

        private void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (Grounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            // 選択すると、接地されたコライダーの位置および一致する半径にギズモが描画されます。
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
                GroundedRadius);
        }

        private void OnFootstep(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                if (FootstepAudioClips.Length > 0)
                {
                    var index = Random.Range(0, FootstepAudioClips.Length);
                    AudioSource.PlayClipAtPoint(FootstepAudioClips[index], transform.TransformPoint(_controller.center), FootstepAudioVolume);
                }
            }
        }

        private void OnLand(AnimationEvent animationEvent)
        {
            if (animationEvent.animatorClipInfo.weight > 0.5f)
            {
                AudioSource.PlayClipAtPoint(LandingAudioClip, transform.TransformPoint(_controller.center), FootstepAudioVolume);
            }
        }
        //IEnumerator ReturnSatoru()
        //{
        //    satobe = false;
        //    yield return new WaitForSeconds(18.0f);
        //    satobe = true;
        //}
        //IEnumerator ReturnJyaku()
        //{
        //    jyakube = false;
        //    yield return new WaitForSeconds(4.0f);
        //    jyakube = true;
        //}
        //IEnumerator ReturnHomi()
        //{
        //    homingbe = false;
        //    yield return new WaitForSeconds(3.0f);
        //    homingbe = true;
        //}
        //public void Attack()
        //{


        //    if (Input.GetKeyDown(KeyCode.Alpha1))
        //    {
        //        efectnunber = 0;
        //    }
        //    if (Input.GetKeyDown(KeyCode.Alpha2))
        //    {
        //        efectnunber = 1;
        //    }
        //    if (Input.GetKeyDown(KeyCode.Alpha3))
        //    {
        //        efectnunber = 2;
        //    }

        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        switch (efectnunber)
        //        {
        //            case 0:
        //                if (satobe)
        //                {

        //                    obj = (GameObject)Instantiate(satoruEfect[0], satoruSpoon.transform.position, transform.rotation);
        //                    obj.transform.parent = gameObject.transform;

        //                    StartCoroutine("ReturnSatoru");
        //                }
        //                break;
        //            case 1:
        //                if (jyakube)
        //                {

        //                    obj = (GameObject)Instantiate(satoruEfect[1], satoruSpoon.transform.position, transform.rotation);
        //                    obj.transform.parent = gameObject.transform;
        //                    StartCoroutine("ReturnJyaku");
        //                }
        //                break;
        //            case 2:
        //                if (homingbe)
        //                {

        //                    obj = (GameObject)Instantiate(satoruEfect[2], satoruSpoon.transform.position, transform.rotation);
        //                    obj.transform.parent = gameObject.transform;
        //                    StartCoroutine("ReturnHomi");
        //                }

        //                break;
        //        }



        //        //攻撃処理をここに書く。
        //        //Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
        //        //gameObject.transform.parent = satoruEfect.gameObject.transform;
        //    }

        //}
    }
}


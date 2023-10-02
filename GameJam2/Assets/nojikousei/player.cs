using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector2 mouseInput;//ユーザーのマウス入力を格納
    public float mouseSensitivity = 1f;//視点移動の速度
    private float verticalMouseInput;//y軸の回転を格納　回転を制限したいから
    private Vector3 moveDir;//プレイヤーの入力を格納（移動）
    private Vector3 movement;//進む方向を格納する変数
    private float activeMoveSpeed = 10;//実際の移動速度
    bool dush = false;//ダッシュ判定
    float upFly = 1.75f;//上昇するスピード
    public GameObject camera;
    Camera maincamera;
    public GameObject[] satoruEfect;//ビームのエフェクト
    public GameObject satorusppon;//生成する場所
    bool attack = false;
    GameObject obj;
    Vector3 angle;
    public float anglestop = 30f;
    int efectnunber = 0;
    public GameObject playerobj;
    float cooltime;
    float cooltime1;
    float cooltime2;
    bool satobe = true;
    bool jyakube = true;
    bool homingbe = true;
    Vector3 muki;
    public GameObject kubi;
    //Vector3 angle;//カメラの縦アングル
    //public float anglestop=30f;//アングル制御
    // Start is called before the first frame update
    void Start()
    {
        maincamera = camera.GetComponent<Camera>();// Cameraの値を取得
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();//移動処理
        Rotate();//回転、カメラアングル
        Fly();//上昇、下降
        Attack();//攻撃
        Zoom();//ズーム
        //Dead();
    }
    //回転、カメラアングル
    void Rotate()
    {
        //変数にユーザーのマウスの動きを格納
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //横回転を反映(transform.eulerAnglesはオイラー角としての角度が返される)
        transform.rotation = Quaternion.Euler
            (0 ,
            transform.eulerAngles.y + mouseInput.x, //マウスのx軸の入力を足す
            0);

        //angle += new Vector3(Input.GetAxisRaw("Mouse Y"), 0, 0);
        //transform.localEulerAngles = -angle;
        //if (angle.x >= anglestop)
        //{
        //    angle.x = anglestop;
        //}
        //if (angle.x <= -anglestop)
        //{
        //    angle.x = -anglestop;
        //}
        //変数にy軸のマウス入力分の数値を足す
        //verticalMouseInput += mouseInput.y;

        ////変数の数値を丸める（上下の視点制御）
        //verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

    }
    //移動処理
    public void PlayerMove()
    {
        muki = transform.forward;
        dush = false;
        //変数の水平と垂直の入力を格納する（wasdや矢印の入力）
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),
            0, Input.GetAxisRaw("Vertical"));

        //ゲームオブジェクトのｚ軸とx軸に入力された値をかけると進む方向が出せる
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized;
        //ダッシュするかどうかの判定
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dush = true;//シフトと同時押しで速度アップ
        }
        if (dush)
        {
            //現在位置に進む方向＊移動スピード*2＊フレーム間秒数を足す
            transform.position += movement * activeMoveSpeed * 3 * Time.deltaTime;
        }
        else
        {
            //現在位置に進む方向＊移動スピード＊フレーム間秒数を足す
            transform.position += movement * activeMoveSpeed * Time.deltaTime;
        }
        //現在位置に進む方向＊移動スピード＊フレーム間秒数を足す
        transform.position += movement * activeMoveSpeed * Time.deltaTime;
    }
    //上昇、下降
    void Fly()
    {
        //スペースキーを押したら上昇する
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, upFly, 0);
        }
        //コントロールキーを押したら下降する
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position -= new Vector3(0, upFly, 0);
        }

    }
    //攻撃
    void Attack()
    {
        if(!satobe)
        {
            cooltime += Time.deltaTime;
            if(cooltime>12f)
            {
                satobe = true;
            }
        }
        if (!jyakube)
        {
            cooltime += Time.deltaTime;
            if (cooltime > 4f)
            {
                jyakube = true;
            }
        }
        if (!homingbe)
        {
            cooltime += Time.deltaTime;
            if (cooltime > 3f)
            {
                homingbe = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            efectnunber = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            efectnunber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            efectnunber = 2;
        }
        
        if (Input.GetMouseButtonDown(0))
        {
            switch (efectnunber)
            {
                case 0:
                    if(satobe)
                    {
                        
                        obj = (GameObject)Instantiate(satoruEfect[0], satorusppon.transform.position, Quaternion.identity);
                        obj.transform.parent = camera.transform;
                        satobe = false;
                    }
                    break;
                case 1:
                    if (jyakube)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[1], satorusppon.transform.position, transform.rotation);
                        obj.transform.parent = camera.transform;
                        satobe = false;
                    }
                    break;
                case 2:
                    if (homingbe)
                    {

                        obj = (GameObject)Instantiate(satoruEfect[2], satorusppon.transform.position, Quaternion.identity);
                        obj.transform.parent = camera.transform;
                        satobe = false;
                    }
                   
                    break;
            }
            
                
            
            //攻撃処理をここに書く。
            //Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
            //gameObject.transform.parent = satoruEfect.gameObject.transform;
        }

    }
    //ズーム
    void Zoom()
    {
        maincamera.fieldOfView = 60.0f;
        //ボタンを押してる間
        if (Input.GetMouseButton(1))
        {
            maincamera.fieldOfView = 10.0f;
            //if(maincamera.fieldOfView<=20f)
            //{
            //    maincamera.fieldOfView = 20f;
            //}
        }
    }

    private void FixedUpdate()
    {
        Cursor.visible = false;

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector2 mouseInput;//ユーザーのマウス入力を格納
    public float mouseSensitivity = 1f;//視点移動の速度
    private float verticalMouseInput;//y軸の回転を格納　回転を制限したいから
    private Vector3 moveDir;//プレイヤーの入力を格納（移動）
    private Vector3 movement;//進む方向を格納する変数
    private float activeMoveSpeed = 4;//実際の移動速度
    bool dush = false;//ダッシュ判定
    float upFly = 0.01f;//上昇するスピード
    //public GameObject camera;
    Camera maincamera;
    GameObject obj;
    Vector3 angle;
    public float anglestop = 30f;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();//移動処理
        Rotate();//回転、カメラアングル
        Fly();//上昇、下降
        
    }
    //回転、カメラアングル
    void Rotate()
    {
        //変数にユーザーのマウスの動きを格納
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //横回転を反映(transform.eulerAnglesはオイラー角としての角度が返される)
        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x+mouseInput.y,
            transform.eulerAngles.y + mouseInput.x, //マウスのx軸の入力を足す
            transform.eulerAngles.z);

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
   
}

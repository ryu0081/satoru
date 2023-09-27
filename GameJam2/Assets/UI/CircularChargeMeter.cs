using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularChargeMeter : MonoBehaviour
{
    public Image fillImage; // チャージゲージの色が変化するイメージ
    public float chargeRate = 1.0f; // チャージ速度（調整可能）
    public float maxChargeValue = 1.0f; // チャージの最大値（1.0が最大）

    private bool isCharging = false; // チャージ中かどうかのフラグ
    private float currentCharge = 0.0f; // 現在のチャージ量

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // 左クリックを長押し中かどうかをチェック
        {
            if (!isCharging)
            {
                // チャージを開始する
                isCharging = true;
                currentCharge = 0.0f;
            }

            // チャージを増やす
            currentCharge += chargeRate * Time.deltaTime;

            // チャージゲージを更新
            fillImage.fillAmount = currentCharge / maxChargeValue;

            // チャージが最大値に達した場合の処理
            if (currentCharge >= maxChargeValue)
            {
                // ここで必要なアクションを実行
            }
        }
        else
        {
            // 左クリックを離したらチャージを停止する
            isCharging = false;
        }
    }
}

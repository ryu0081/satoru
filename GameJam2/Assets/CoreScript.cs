using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{

    private ParticleSystem particleSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        // エフェクトにアタッチされた ParticleSystem コンポーネントを取得
        particleSystem = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        // 衝突したオブジェクトが敵または地面であるかを確認
        if (other.CompareTag("Enemy") || other.CompareTag("Ground") && !other.CompareTag("Player"))
        {
            // Sub Emitters を有効にする
            EnableSubEmitters();
        }
    }
    private void EnableSubEmitters()
    {
        // Particle System の main モジュールを取得
        var mainModule = particleSystem.main;

        // Sub Emitters を有効にする
        mainModule.playOnAwake = true; // エフェクトが生成されると再生されるように設定
    }
}

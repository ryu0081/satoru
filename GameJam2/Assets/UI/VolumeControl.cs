using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    public AudioSource audioSource;  //BGMが入っているGameObjectをここに入れる

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefsから保存された音量を読み込む
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            // 初期値を設定
            volumeSlider.value = audioSource.volume;
        }

        // スライダーの値が変更されたときに呼び出されるイベントハンドラを設定
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    }

    // スライダーの値が変更されたときに呼び出されるメソッド
    private void ChangeVolume(float volume)
    {
        // オーディオソースの音量をスライダーの値に設定
        audioSource.volume = volume;

        // 変更された音量をPlayerPrefsに保存
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save(); // 重要: 保存を確定するために必要
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Closepanel : MonoBehaviour
{
    public GameObject panel; // 閉じる対象のパネル

    // パネルを閉じるメソッド
    public void ClosePanel()
    {
        panel.SetActive(false); // パネルを非表示にする
    }
}

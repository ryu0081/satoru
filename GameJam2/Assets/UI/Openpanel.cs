using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Openpanel : MonoBehaviour
{
    public GameObject panel; // パネルの参照


    // ボタンがクリックされたときに呼び出されるメソッド
    public void ShowPanel()
    {
        panel.SetActive(true); // パネルを表示する
    }

}

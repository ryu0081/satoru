using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitGameOnClick : MonoBehaviour
{
    private Button exitButton;

    // Start is called before the first frame update
    void Start()
    {
        // UIイメージのボタンコンポーネントを取得
        exitButton = GetComponent<Button>();

        // ボタンがクリックされたらExitGameメソッドを呼び出す
        if (exitButton != null)
        {
            exitButton.onClick.AddListener(ExitGame);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ExitGame()
    {
        // ゲームを終了する（エディタ内では動作しません）
        Application.Quit();
    }
}

using UnityEngine.UI;
using UnityEngine;

public class UIpanel : MonoBehaviour
{
    public GameObject panel; // パネルの参照をInspectorから設定
    public Button closeButton; // Imageボタンの参照をInspectorから設定
    public GameObject Gage; //ゲージの参照

    private void Start()
    {
        panel.SetActive(false); // 初期状態でパネルを非表示に設定

        closeButton.gameObject.SetActive(false); // 初期状態でボタンを非表示に設定

        // Imageボタンのクリックイベントに閉じる処理を追加
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true); // ESCキーが押されたらパネルを表示

            Gage.SetActive(false);//ゲージはFalseに

            closeButton.gameObject.SetActive(true);// ESCキーが押されたらボタンを表示
        }
    }
    public void ClosePanel()
    {
        panel.SetActive(false); // Imageボタンをクリックしてパネルを閉じる

        closeButton.gameObject.SetActive(false);

        Gage.SetActive(true); //閉じたらまたTrueに
    }
}

using UnityEngine.UI;
using UnityEngine;

public class UIpanel : MonoBehaviour
{
    public GameObject panel; // �p�l���̎Q�Ƃ�Inspector����ݒ�
    public Button closeButton; // Image�{�^���̎Q�Ƃ�Inspector����ݒ�


    private void Start()
    {
        panel.SetActive(false); // ������ԂŃp�l�����\���ɐݒ�

        closeButton.gameObject.SetActive(false); // ������ԂŃ{�^�����\���ɐݒ�

        // Image�{�^���̃N���b�N�C�x���g�ɕ��鏈����ǉ�
        closeButton.onClick.AddListener(ClosePanel);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            panel.SetActive(true); // ESC�L�[�������ꂽ��p�l����\��

            closeButton.gameObject.SetActive(true);// ESC�L�[�������ꂽ��{�^����\��
        }
    }
    public void ClosePanel()
    {
        panel.SetActive(false); // Image�{�^�����N���b�N���ăp�l�������

        closeButton.gameObject.SetActive(false);
    }
}

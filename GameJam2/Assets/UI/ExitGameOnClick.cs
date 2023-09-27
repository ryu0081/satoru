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
        // UI�C���[�W�̃{�^���R���|�[�l���g���擾
        exitButton = GetComponent<Button>();

        // �{�^�����N���b�N���ꂽ��ExitGame���\�b�h���Ăяo��
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
        // �Q�[�����I������i�G�f�B�^���ł͓��삵�܂���j
        Application.Quit();
    }
}

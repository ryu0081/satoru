using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndButton : MonoBehaviour
{
    // Start is called before the first frame update
    //�Q�[���I��:�{�^������Ăяo��
    public void EndGame()
    {

#if UNITY_EDITOR

        UnityEditor.EditorApplication.isPlaying = false;//�Q�[���v���C�I��
#else
    Application.Quit();//�Q�[���v���C�I��
#endif
    }
}

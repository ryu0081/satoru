using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public Slider volumeSlider;

    public AudioSource audioSource;  //BGM�������Ă���GameObject�������ɓ����

    // Start is called before the first frame update
    void Start()
    {
        // PlayerPrefs����ۑ����ꂽ���ʂ�ǂݍ���
        if (PlayerPrefs.HasKey("Volume"))
        {
            float savedVolume = PlayerPrefs.GetFloat("Volume");
            volumeSlider.value = savedVolume;
            audioSource.volume = savedVolume;
        }
        else
        {
            // �����l��ݒ�
            volumeSlider.value = audioSource.volume;
        }

        // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��ɌĂяo�����C�x���g�n���h����ݒ�
        volumeSlider.onValueChanged.AddListener(ChangeVolume);

    }

    // �X���C�_�[�̒l���ύX���ꂽ�Ƃ��ɌĂяo����郁�\�b�h
    private void ChangeVolume(float volume)
    {
        // �I�[�f�B�I�\�[�X�̉��ʂ��X���C�_�[�̒l�ɐݒ�
        audioSource.volume = volume;

        // �ύX���ꂽ���ʂ�PlayerPrefs�ɕۑ�
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save(); // �d�v: �ۑ����m�肷�邽�߂ɕK�v
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

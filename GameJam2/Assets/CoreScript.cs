using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreScript : MonoBehaviour
{

    private ParticleSystem particleSystem;
    

    // Start is called before the first frame update
    void Start()
    {
        // �G�t�F�N�g�ɃA�^�b�`���ꂽ ParticleSystem �R���|�[�l���g���擾
        particleSystem = GetComponent<ParticleSystem>();

    }

    // Update is called once per frame
    private void OnParticleCollision(GameObject other)
    {
        // �Փ˂����I�u�W�F�N�g���G�܂��͒n�ʂł��邩���m�F
        if (other.CompareTag("Enemy") || other.CompareTag("Ground") && !other.CompareTag("Player"))
        {
            // Sub Emitters ��L���ɂ���
            EnableSubEmitters();
        }
    }
    private void EnableSubEmitters()
    {
        // Particle System �� main ���W���[�����擾
        var mainModule = particleSystem.main;

        // Sub Emitters ��L���ɂ���
        mainModule.playOnAwake = true; // �G�t�F�N�g�����������ƍĐ������悤�ɐݒ�
    }
}

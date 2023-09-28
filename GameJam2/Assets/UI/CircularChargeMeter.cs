using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircularChargeMeter : MonoBehaviour
{
    public Image fillImage; // �`���[�W�Q�[�W�̐F���ω�����C���[�W
    public float chargeRate = 1.0f; // �`���[�W���x�i�����\�j
    public float maxChargeValue = 1.0f; // �`���[�W�̍ő�l�i1.0���ő�j

    private bool isCharging = false; // �`���[�W�����ǂ����̃t���O
    private float currentCharge = 0.0f; // ���݂̃`���[�W��

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) // ���N���b�N�𒷉��������ǂ������`�F�b�N
        {
            if (!isCharging)
            {
                // �`���[�W���J�n����
                isCharging = true;
                currentCharge = 0.0f;
            }

            // �`���[�W�𑝂₷
            currentCharge += chargeRate * Time.deltaTime;

            // �`���[�W�Q�[�W���X�V
            fillImage.fillAmount = currentCharge / maxChargeValue;

            // �`���[�W���ő�l�ɒB�����ꍇ�̏���
            if (currentCharge >= maxChargeValue)
            {
                // �����ŕK�v�ȃA�N�V���������s
            }
        }
        else
        {
            // ���N���b�N�𗣂�����`���[�W���~����
            isCharging = false;
        }
    }
}

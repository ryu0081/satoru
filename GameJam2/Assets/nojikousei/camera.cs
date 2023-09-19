using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    private Vector2 mouseInput;//���[�U�[�̃}�E�X���͂��i�[
    public float mouseSensitivity = 1f;//���_�ړ��̑��x
    private float verticalMouseInput;//y���̉�]���i�[�@��]�𐧌�����������
    private Vector3 moveDir;//�v���C���[�̓��͂��i�[�i�ړ��j
    private Vector3 movement;//�i�ޕ������i�[����ϐ�
    private float activeMoveSpeed = 4;//���ۂ̈ړ����x
    bool dush = false;//�_�b�V������
    float upFly = 0.01f;//�㏸����X�s�[�h
    //public GameObject camera;
    Camera maincamera;
    GameObject obj;
    Vector3 angle;
    public float anglestop = 30f;
    
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();//�ړ�����
        Rotate();//��]�A�J�����A���O��
        Fly();//�㏸�A���~
        
    }
    //��]�A�J�����A���O��
    void Rotate()
    {
        //�ϐ��Ƀ��[�U�[�̃}�E�X�̓������i�[
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //����]�𔽉f(transform.eulerAngles�̓I�C���[�p�Ƃ��Ă̊p�x���Ԃ����)
        transform.rotation = Quaternion.Euler
            (transform.eulerAngles.x+mouseInput.y,
            transform.eulerAngles.y + mouseInput.x, //�}�E�X��x���̓��͂𑫂�
            transform.eulerAngles.z);

        //angle += new Vector3(Input.GetAxisRaw("Mouse Y"), 0, 0);
        //transform.localEulerAngles = -angle;
        //if (angle.x >= anglestop)
        //{
        //    angle.x = anglestop;
        //}
        //if (angle.x <= -anglestop)
        //{
        //    angle.x = -anglestop;
        //}
        //�ϐ���y���̃}�E�X���͕��̐��l�𑫂�
        //verticalMouseInput += mouseInput.y;

        ////�ϐ��̐��l���ۂ߂�i�㉺�̎��_����j
        //verticalMouseInput = Mathf.Clamp(verticalMouseInput, -60f, 60f);

    }
    //�ړ�����
    public void PlayerMove()
    {
        dush = false;
        //�ϐ��̐����Ɛ����̓��͂��i�[����iwasd����̓��́j
        moveDir = new Vector3(Input.GetAxisRaw("Horizontal"),
            0, Input.GetAxisRaw("Vertical"));

        //�Q�[���I�u�W�F�N�g�̂�����x���ɓ��͂��ꂽ�l��������Ɛi�ޕ������o����
        movement = ((transform.forward * moveDir.z) + (transform.right * moveDir.x)).normalized;
        //�_�b�V�����邩�ǂ����̔���
        if (Input.GetKey(KeyCode.LeftShift))
        {
            dush = true;//�V�t�g�Ɠ��������ő��x�A�b�v
        }
        if (dush)
        {
            //���݈ʒu�ɐi�ޕ������ړ��X�s�[�h*2���t���[���ԕb���𑫂�
            transform.position += movement * activeMoveSpeed * 3 * Time.deltaTime;
        }
        else
        {
            //���݈ʒu�ɐi�ޕ������ړ��X�s�[�h���t���[���ԕb���𑫂�
            transform.position += movement * activeMoveSpeed * Time.deltaTime;
        }
        //���݈ʒu�ɐi�ޕ������ړ��X�s�[�h���t���[���ԕb���𑫂�
        transform.position += movement * activeMoveSpeed * Time.deltaTime;
    }
    //�㏸�A���~
    void Fly()
    {
        //�X�y�[�X�L�[����������㏸����
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, upFly, 0);
        }
        //�R���g���[���L�[���������牺�~����
        if (Input.GetKey(KeyCode.LeftControl))
        {
            transform.position -= new Vector3(0, upFly, 0);
        }

    }
   
}

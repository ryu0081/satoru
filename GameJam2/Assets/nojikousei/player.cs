using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector2 mouseInput;//���[�U�[�̃}�E�X���͂��i�[
    public float mouseSensitivity = 1f;//���_�ړ��̑��x
    private float verticalMouseInput;//y���̉�]���i�[�@��]�𐧌�����������
    private Vector3 moveDir;//�v���C���[�̓��͂��i�[�i�ړ��j
    private Vector3 movement;//�i�ޕ������i�[����ϐ�
    private float activeMoveSpeed = 4;//���ۂ̈ړ����x
    bool dush = false;//�_�b�V������
    float upFly = 0.01f;//�㏸����X�s�[�h
    public GameObject camera;
    Camera maincamera;
    public GameObject satoruEfect;//�r�[���̃G�t�F�N�g
    public GameObject satorusppon;//��������ꏊ
    bool attack = false;
    GameObject obj;
    Vector3 angle;
    public float anglestop = 30f;
    //Vector3 angle;//�J�����̏c�A���O��
    //public float anglestop=30f;//�A���O������
    // Start is called before the first frame update
    void Start()
    {
        maincamera = camera.GetComponent<Camera>();// Camera�̒l���擾
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();//�ړ�����
        Rotate();//��]�A�J�����A���O��
        Fly();//�㏸�A���~
        Attack();//�U��
        Zoom();//�Y�[��
        //Dead();
    }
    //��]�A�J�����A���O��
    void Rotate()
    {
        //�ϐ��Ƀ��[�U�[�̃}�E�X�̓������i�[
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X") * mouseSensitivity,
            Input.GetAxisRaw("Mouse Y") * mouseSensitivity);

        //����]�𔽉f(transform.eulerAngles�̓I�C���[�p�Ƃ��Ă̊p�x���Ԃ����)
        transform.rotation = Quaternion.Euler
            (0 ,
            transform.eulerAngles.y + mouseInput.x, //�}�E�X��x���̓��͂𑫂�
            0);

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
    //�U��
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            
            
                obj = (GameObject)Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
                obj.transform.parent = camera.transform;
                
            
            //�U�������������ɏ����B
            //Instantiate(satoruEfect, satorusppon.transform.position, Quaternion.identity);
            //gameObject.transform.parent = satoruEfect.gameObject.transform;
        }

    }
    //�Y�[��
    void Zoom()
    {
        maincamera.fieldOfView = 60.0f;
        //�{�^���������Ă��
        if (Input.GetMouseButton(1))
        {
            maincamera.fieldOfView = 20.0f;
            //if(maincamera.fieldOfView<=20f)
            //{
            //    maincamera.fieldOfView = 20f;
            //}
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemycpuManager : MonoBehaviour
{
    public enum EnemyAiState
    {
        Idle,        //�ҋ@
        Walk,        //�p�j
        Chase,       //�ǐ�
        Leave,       //����
        Alert,       //�x��
        Freeze,      //�d��
        Slashattack, //�ߐڍU��
        Laserbeam,   //�������U��1
        Laserbullet, //�������U��2
    }
    public EnemyAiState Enemystate =EnemyAiState.Idle;
    public int tactic = 1;  //�󋵂̔��ʗp�p�����[�^



    void setAI()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

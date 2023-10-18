using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemycpuManager : MonoBehaviour
{
    public enum EnemyAiState
    {
        Idle,        //‘Ò‹@
        Walk,        //œpœj
        Chase,       //’ÇÕ
        Leave,       //“¦‘–
        Alert,       //Œx‰ú
        Freeze,      //d’¼
        Slashattack, //‹ßÚUŒ‚
        Laserbeam,   //‰“‹——£UŒ‚1
        Laserbullet, //‰“‹——£UŒ‚2
    }
    public EnemyAiState Enemystate =EnemyAiState.Idle;
    public int tactic = 1;  //ó‹µ‚Ì”»•Ê—pƒpƒ‰ƒ[ƒ^



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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPManger : MonoBehaviour
{
    public buildController[] bc;

    bool[] isDamage = new bool[4];

    bool[] isPlayer = new bool[4];
    bool[] isEnemy = new bool[4];

    float damage = 0.1f;

    public float pScore = 0;           //プレイヤー用のスコア
    public float eScore = 0;           //Enemy用のスコア

    public bool isFinish = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isDamage[0] = bc[0].isDamage;               //ダメージを与えている時、プレイヤーか敵が判断する
        isDamage[1] = bc[1].isDamage;
        isDamage[2] = bc[2].isDamage;
        isDamage[3] = bc[3].isDamage;

        isPlayer[0] = bc[0].isPlayer;
        isPlayer[1] = bc[1].isPlayer;
        isPlayer[2] = bc[2].isPlayer;
        isPlayer[3] = bc[3].isPlayer;

        isEnemy[0] = bc[0].isEnemy;
        isEnemy[1] = bc[1].isEnemy;
        isEnemy[2] = bc[2].isEnemy;
        isEnemy[3] = bc[3].isEnemy;

        HP();
    }

    void HP()
    {
        if (isDamage[0] | isDamage[1] | isDamage[2] || isDamage[3])             //ダメージが当たっている時
        {
            if (isPlayer[0] || isPlayer[1] || isPlayer[2] || isPlayer[3])       //プレイヤーが建物を破壊しているとき
            {
                GetComponent<Image>().fillAmount -= damage;
                if (GetComponent<Image>().fillAmount == 0)
                {
                    isFinish = true;
                }
                pScore += 0.001f;
            }

            if (isEnemy[0] || isEnemy[1] || isEnemy[2] || isEnemy[3])           //Enemyが建物を破壊しているとき
            {
                GetComponent<Image>().fillAmount -= damage;
                if (GetComponent<Image>().fillAmount == 0) isFinish = true;

                eScore += 0.001f;

            }
        }
    }
}

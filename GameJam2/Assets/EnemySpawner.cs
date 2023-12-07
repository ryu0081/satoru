using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform spawnPoint;
    public float spawnInterval = 2f;

    void Start()
    {
        // ���Ԋu�œG�𐶐����邽�߂̃R���[�`�����J�n
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // �G�𐶐�����
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // �w�肳�ꂽ�Ԋu�����ҋ@
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}


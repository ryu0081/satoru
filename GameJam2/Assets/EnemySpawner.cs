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
        // 一定間隔で敵を生成するためのコルーチンを開始
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            // 敵を生成する
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            // 指定された間隔だけ待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }
}


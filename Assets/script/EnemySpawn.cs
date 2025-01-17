using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    public static EnemySpawn Instance { get; private set; }

    [SerializeField] private GameObject[] enemy;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] public GameObject[] max = new GameObject[5];

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            Spawn();
        }
    }

    private void Spawn()
    {
        if (GameManager.Instance.BossSpawned)
        {
            return;
        }
        var spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (max[spawnPointIndex] == null)
        {
            if (!GameManager.Instance.isBossDie1)
            {
                var newEnemy = Instantiate(enemy[Random.Range(0, 1)], spawnPoints[spawnPointIndex].position,
                    spawnPoints[spawnPointIndex].rotation);
                if (newEnemy.GetComponent<MonsterControllor>() != null)
                {
                    GameManager.Instance.monsters.Add(newEnemy);
                    max[spawnPointIndex] = newEnemy;
                }
                else
                {
                    GameManager.Instance.rocks.Add(newEnemy);
                }
            }
            else
            {
                var newEnemy = Instantiate(enemy[Random.Range(2, 3)], spawnPoints[spawnPointIndex].position,
                    spawnPoints[spawnPointIndex].rotation);
                if (newEnemy.GetComponent<MonsterControllor>() != null)
                {
                    GameManager.Instance.monsters.Add(newEnemy);
                    max[spawnPointIndex] = newEnemy;
                }
                else
                {
                    GameManager.Instance.rocks.Add(newEnemy);
                }
            }
        }
    }
}
using System;
using System.Collections;
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
        var spawnPointIndex = Random.Range(0, spawnPoints.Length);
        if (max[spawnPointIndex] == null)
        {
            var newEnemy = Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            max[spawnPointIndex] = newEnemy;
        }
    }
}
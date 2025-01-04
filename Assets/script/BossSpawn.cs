using System;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    [SerializeField] private GameObject BossPrefab;
    [SerializeField] private Transform spawnPoint;

    private void Update()
    {
        if(GameManager.Instance.score >= 1000 && GameManager.Instance.score < 1300)
        {
            if (!GameManager.Instance.BossSpawned)
            {
                var Boss = Instantiate(BossPrefab, spawnPoint.position, spawnPoint.rotation);
                GameManager.Instance.Boss = Boss;
                UIManager.Instance.BossUI.Show();
                GameManager.Instance.BossSpawned = true;
            }

        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MonsterControllor : BaseControllor
{
    [SerializeField] public float Hp = 100;
    [SerializeField] private GameObject Ammo;
    [SerializeField] private GameObject[] bup;

    private void Start()
    {
        StartCoroutine(Attack());
    }

    private void Update()
    {
        if (Hp <= 0)
        {
            int a = Random.Range(0, bup.Length);
            if (bup[a] != null)
            {
                Instantiate(bup[a], transform.position, transform.rotation);
            }
            GameManager.Instance.score += 100;
            for (int i = 0; i < EnemySpawn.Instance.max.Length; i++)
            {
                if (EnemySpawn.Instance.max[i] == transform.gameObject)
                {
                    EnemySpawn.Instance.max[i] = null;
                }
            }
            GameManager.Instance.monsters.Remove(gameObject);
            Destroy(gameObject);
        }
    }
    
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2, 4));
        Attack(Ammo, 15);
        StartCoroutine(Attack());
    }
}

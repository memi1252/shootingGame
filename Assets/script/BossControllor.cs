using System.Collections;
using UnityEngine;

public class BossControllor : BaseControllor
{
    [SerializeField] public float Hp = 1000;
    [SerializeField] private GameObject Ammo;
    [SerializeField] private GameObject[] bup;
    
    private void Start()
    {
        StartCoroutine(Attack());
    }
    
    private void Update()
    {
        if (Hp <= 0 && GameManager.Instance.isBossDie1 == false)
        {
            int a = Random.Range(0, bup.Length);
            if (bup[a] != null)
            {
                Instantiate(bup[a], transform.position, transform.rotation);
            }
            GameManager.Instance.score += 300;
            GameManager.Instance.BossSpawned = false;
            UIManager.Instance.BossUI.Hide();
            GameManager.Instance.isBossDie1 = true;
            Destroy(gameObject);
        }else if(Hp <= 0 && GameManager.Instance.isBossDie1 == true)
        {
            int a = Random.Range(0, bup.Length);
            if (bup[a] != null)
            {
                Instantiate(bup[a], transform.position, transform.rotation);
            }
            GameManager.Instance.score += 600;
            GameManager.Instance.BossSpawned = false;
            UIManager.Instance.BossUI.Hide();
            Destroy(gameObject);
        }
    }
    
    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(1, 3));
        Attack(Ammo, 30);
        StartCoroutine(Attack());
    }
}

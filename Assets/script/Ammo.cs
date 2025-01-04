using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public float damage = 20;

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(Ammoremove());
    }

    

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.tag == "Monster")
            {
                hit.collider.GetComponent<MonsterControllor>().Hp -= damage;
                Debug.Log("Hit");
                audioSource.clip = audioClip;
                audioSource.Play();
                Destroy(gameObject);
            }
            else if (hit.collider.tag == "Player")
            {
                if (GameManager.Instance.nerverDie)
                {
                    return;
                }
                hit.collider.GetComponent<PlayerControllor>().Durability -= damage;
                Debug.Log("Hit");
                audioSource.clip = audioClip;
                audioSource.Play();
                Destroy(gameObject);
            }
            else if (hit.collider.tag == "Boss")
            {
                hit.collider.GetComponent<BossControllor>().Hp -= damage;
                Debug.Log("Hit");
                audioSource.clip = audioClip;
                audioSource.Play();
                Destroy(gameObject);
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 1, Color.red);
    }

    IEnumerator Ammoremove()
    {
        yield return new WaitForSeconds(5f);
        GameManager.Instance.ammos.Remove(gameObject);
        Destroy(gameObject);
    }
}

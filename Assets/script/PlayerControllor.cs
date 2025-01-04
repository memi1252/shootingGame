using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Random = UnityEngine.Random;

public class PlayerControllor : BaseControllor
{
    
    [SerializeField] public float Durability = 100; // 내구도
    [SerializeField] public float fuel = 100;// 연료
    [SerializeField] private GameObject Ammo;
    [SerializeField] private AudioClip attacClip;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] public int Damage = 20;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(fuelDown());
    }

    private void Update()
    {
        move(100);
        if (Input.GetKeyDown(KeyCode.E))
        {
            Attack(Ammo, Damage);
            audioSource.clip = attacClip;
            audioSource.Play();
        }

        if (fuel == 0)
        {
            GameManager.Instance.playerDie = true;
        }
    }
    
    public void move(float speed)
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(h, 0, v);
        transform.Translate(dir.normalized * Time.deltaTime * speed);
        if(transform.position.x < -65)
        {
            transform.position = new Vector3(-65, transform.position.y, transform.position.z);
        }
        else if(transform.position.x > 65)
        {
            transform.position = new Vector3(65, transform.position.y, transform.position.z);
        }else if (transform.position.z > 200)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 200);
        }
        else if( transform.position.z < 0)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }
        
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "EnemyAmmo")
        {
            Durability -= 10;
        }
    }
    
    IEnumerator fuelDown() 
    {
        yield return new WaitForSeconds(5);
        fuel -= Random.Range(4, 8);
        StartCoroutine(fuelDown());
    }
}

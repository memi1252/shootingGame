using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeUp : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>();
    }

    private void Start()
    {
        StartCoroutine(remove());
    }

    

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.tag == "Player")
            {
                if(hit.collider.GetComponent<PlayerControllor>().DamageUpCount < 5)
                {
                    hit.collider.GetComponent<PlayerControllor>().Damage += 5;
                    hit.collider.GetComponent<PlayerControllor>().DamageUpCount++;
                    Debug.Log("DamigeUP");
                    audioSource.clip = audioClip;
                    audioSource.Play();
                    Destroy(gameObject);
                }
                else
                {
                    hit.collider.GetComponent<PlayerControllor>().Score += 100;
                }
            }
            
        }
        Debug.DrawRay(transform.position, transform.forward * 1, Color.red);
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}

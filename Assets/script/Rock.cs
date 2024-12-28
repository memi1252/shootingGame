using System.Collections;
using UnityEngine;

public class Rock : MonoBehaviour
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
                hit.collider.GetComponent<PlayerControllor>().Durability -= damage;
                Debug.Log("Hit");
                audioSource.clip = audioClip;
                audioSource.Play();
                Destroy(gameObject);
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

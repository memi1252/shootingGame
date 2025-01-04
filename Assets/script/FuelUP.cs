using System.Collections;
using UnityEngine;

public class FuelUP : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private AudioSource audioSource;
    

    private void Awake()
    {
        audioSource = GameManager.Instance.PlayerControllor.GetComponent<AudioSource>();
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
                GameManager.Instance.PlayerControllor.fuel += 20;
                Debug.Log("fuelUP");
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

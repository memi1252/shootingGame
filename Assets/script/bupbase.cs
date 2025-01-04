using System.Collections;
using UnityEngine;

public class bupbase : MonoBehaviour
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
        bup();
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }

    public virtual void bup()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 1))
        {
            if (hit.collider.tag == "Player")
            {
                
            }
        }
        Debug.DrawRay(transform.position, transform.forward * 1, Color.red);
    }
}

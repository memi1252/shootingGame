using System.Collections;
using UnityEngine;

public class FuelUP : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private void Start()
    {
        StartCoroutine(remove());
    }

    

    private void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 100);
    }

    IEnumerator remove()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.tag == "Player")
        {
                
            GameManager.Instance.PlayerControllor.fuel += 20;
            Debug.Log("fuelUP");
            SoundManager.Instance.buffAudioSource.clip = audioClip;
            SoundManager.Instance.buffAudioSource.Play();
            Destroy(gameObject);
        }
    }
}

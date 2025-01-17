using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class self_destruct : MonoBehaviour
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
            
            Debug.Log("자살");
            UIManager.Instance.DIeUI.Show();
            SoundManager.Instance.buffAudioSource.clip = audioClip;
            SoundManager.Instance.buffAudioSource.Play();
            Destroy(gameObject);
                
        }
    }
}

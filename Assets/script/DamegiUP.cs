using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamegeUp : MonoBehaviour
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
                
            if(GameManager.Instance.DamageUpCount < 5)
            {
                other.transform.GetComponent<PlayerControllor>().Damage += 5;
                GameManager.Instance.DamageUpCount++;
                Debug.Log("DamigeUP");
                SoundManager.Instance.buffAudioSource.clip = audioClip;
                SoundManager.Instance.buffAudioSource.Play();
                Destroy(gameObject);
            }
            else
            {
                GameManager.Instance.score += 100;
            }
                
        }
    }
}

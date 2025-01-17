using System;
using Unity.VisualScripting;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField] public AudioSource audioSource;
    [SerializeField] public AudioSource buffAudioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        buffAudioSource = transform.AddComponent<AudioSource>();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
}

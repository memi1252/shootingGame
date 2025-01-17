using System;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] public PlayerControllor PlayerControllor;
    
    public List<GameObject> ammos = new List<GameObject>();
    public List<GameObject> monsters = new List<GameObject>();
    public List<GameObject> rocks = new List<GameObject>();
    public GameObject Boss;
    
    public int DamageUpCount = 0;

    public bool nerverDie = false;
    public bool BossSpawned = false;
    public bool isBossDie1 = false;
    
    public int score = 0;
    public float playTime;
    public float nerverDieTime;

    private void Awake()
    {
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

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        playTime += Time.deltaTime;
        if (nerverDie)
        {
            nerverDieTime -= Time.deltaTime;
            if (nerverDieTime <= 0)
            {
                nerverDie = false;
                nerverDieTime = 5;
            }
        }
        PlayerControllor = GameObject.Find("Player").GetComponent<PlayerControllor>();
    }

    
}

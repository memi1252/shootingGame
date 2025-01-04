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
    public bool playerDie = false;
    
    public int score = 0;
    public float playTime;
    public float nerverDieTime;

    private void Awake()
    {
        Instance = this;
        
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

        if (playerDie)
        {
            Time.timeScale = 0;
            UIManager.Instance.DIeUI.Show();
            UIManager.Instance.PlayerState.Hide();
            UIManager.Instance.PlayerSkill.HIDE();
        }
    }

    
}

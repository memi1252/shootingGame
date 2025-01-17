using System;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }
    
    [SerializeField] public PlayerSkill PlayerSkill;
    [SerializeField] public PlayerState PlayerState;
    [SerializeField] public BossUI BossUI;
    [SerializeField] public DIeUI DIeUI;
    [SerializeField] public helpMenu helpMenu;
    [SerializeField] public RankingUI RankingUI;
    
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

    private void Update()
    {

        if (GameObject.Find("Canvas").transform.Find("playerSkill") != null)
        {
            PlayerSkill = GameObject.Find("Canvas").transform.Find("playerSkill").GetComponent<PlayerSkill>();
        }

        if (GameObject.Find("Canvas").transform.Find("playerState") != null)
        {
            PlayerState = GameObject.Find("Canvas").transform.Find("playerState").GetComponent<PlayerState>();
        }

        if (GameObject.Find("Canvas").transform.Find("BossUI") != null)
        {
            BossUI = GameObject.Find("Canvas").transform.Find("BossUI").GetComponent<BossUI>();
        }

        if (GameObject.Find("Canvas").transform.Find("DIeUI") != null)
        {
            DIeUI = GameObject.Find("Canvas").transform.Find("DIeUI").GetComponent<DIeUI>();
        }
    }
}

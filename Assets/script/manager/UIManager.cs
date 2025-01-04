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
    
    private void Awake()
    {
        Instance = this;
    }
}

using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RankingUI : MonoBehaviour
{
    public static RankingUI Instance { get; private set; }
    [SerializeField] public GameObject scorePrefab;
    [SerializeField] public GameObject scoreParent;
    [SerializeField] public Button backButton;
    public List<int> scores = new List<int>();
    
    public int count = 1;
    private void Awake()
    {
        backButton.onClick.AddListener(Hide);
       
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        Hide();
    }
    

    public void Show()
    {
        gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }
}

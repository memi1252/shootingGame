using System;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class BossUI : MonoBehaviour
{
    [SerializeField] private Slider bossHpSlider;

    private void Awake()
    {
        Hide();
    }

    private void Update()
    {
        if (GameManager.Instance.Boss != null)
        {
            bossHpSlider.value = GameManager.Instance.Boss.GetComponent<BossControllor>().Hp / 1000;
        }
        else
        {
            
        }
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

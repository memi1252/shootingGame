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
            if (GameManager.Instance.isBossDie1)
            {
                bossHpSlider.value = GameManager.Instance.Boss.GetComponent<BossControllor>().Hp / 3000;
            }
            else
            {
                bossHpSlider.value = GameManager.Instance.Boss.GetComponent<BossControllor>().Hp / 1000;
            }
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

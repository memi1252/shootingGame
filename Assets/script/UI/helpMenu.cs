using System;
using UnityEngine;
using UnityEngine.UI;

public class helpMenu : MonoBehaviour
{
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        Hide();
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
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

using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class mainMenuUI : MonoBehaviour
{
    [SerializeField] private Button GameStartButton;
    [SerializeField] private Button GameHelpButton;

    private void Awake()
    {
        GameStartButton.onClick.AddListener(() =>
        {
            SceneManager.LoadScene("GameScene");
        });
        GameHelpButton.onClick.AddListener(() =>
        {
            UIManager.Instance.helpMenu.Show();
        });
    }
}

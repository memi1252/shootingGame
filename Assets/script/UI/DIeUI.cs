using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DIeUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI playTime;
   [SerializeField] private TextMeshProUGUI score;
   [SerializeField] private Button restartButton;

   private void Awake()
   {
      Hide();
      restartButton.onClick.AddListener(() =>
      {
         SceneManager.LoadScene("GameScene");
      });
   }
   
   private void Update()
   {
      playTime.text = "Play Time : " + string.Format("{0:D2}:{1:D2}", (int)GameManager.Instance.playTime / 60, (int)GameManager.Instance.playTime % 60);
      score.text = "Score : " + GameManager.Instance.score;
   }

   public void Show()
   {
      gameObject.SetActive(true);
   }

   private void Hide()
   {
      gameObject.SetActive(false);
   }
}

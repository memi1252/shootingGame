using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DIeUI : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI playTime;
   [SerializeField] private TextMeshProUGUI score;
   [SerializeField] private Button restartButton;
   [SerializeField] private Button rankingButton;

   private void Awake()
   {
      Hide();
      restartButton.onClick.AddListener(() =>
      {
         Time.timeScale = 1;
         GameManager.Instance.score = 0;
         GameManager.Instance.playTime = 0;
         GameManager.Instance.isBossDie1 = false;
         GameManager.Instance.DamageUpCount = 0;
         GameManager.Instance.ammos.Clear();
         GameManager.Instance.monsters.Clear();
         GameManager.Instance.rocks.Clear();
         UIManager.Instance.RankingUI.count = 1;
         foreach (Transform child in UIManager.Instance.RankingUI.scoreParent.transform)
         {
            Destroy(child.gameObject) ;
         }
         SceneManager.LoadScene("GameScene");
      });
      rankingButton.onClick.AddListener(() =>
      {
         UIManager.Instance.RankingUI.Show();
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
      UIManager.Instance.RankingUI.scores.Add(GameManager.Instance.score); 
      UIManager.Instance.RankingUI.scores.Sort((a, b) => b.CompareTo(a));
      foreach (var scores in UIManager.Instance.RankingUI.scores)
      {
         var scoreObject = Instantiate(UIManager.Instance.RankingUI.scorePrefab, UIManager.Instance.RankingUI.scoreParent.transform);
         scoreObject.transform.SetParent(UIManager.Instance.RankingUI.scoreParent.transform);
         scoreObject.GetComponent<RankBar>().score.text = scores.ToString();
         scoreObject.GetComponent<RankBar>().RankCount.text = UIManager.Instance.RankingUI.count + ".";
         UIManager.Instance.RankingUI.count++;
      }
   }

   private void Hide()
   {
      gameObject.SetActive(false);
   }
}

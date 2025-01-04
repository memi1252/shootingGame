using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerState : MonoBehaviour
{
   [SerializeField] private TextMeshProUGUI scoreText;
   [SerializeField] private Image durabilityImage;
   [SerializeField] private Image fuelImage;

   private void Update()
   {
      durabilityImage.fillAmount = GameManager.Instance.PlayerControllor.Durability / 100;
      fuelImage.fillAmount = GameManager.Instance.PlayerControllor.fuel / 100;
      scoreText.text = "Score : " + GameManager.Instance.score;
   }

   public void Hide()
   {
      gameObject.SetActive(false);
   }
}

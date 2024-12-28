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
      durabilityImage.fillAmount = PlayerControllor.Instance.Durability / 100;
      fuelImage.fillAmount = PlayerControllor.Instance.fuel / 100;
      scoreText.text = "Score : " + PlayerControllor.Instance.Score;
   }
}

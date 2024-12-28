using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] private Image skill1Image;
    [SerializeField] private Image skill2Image;
    
    [SerializeField] private bool isSkill1CoolTime = false;
    [SerializeField] private bool isSkill2CoolTime = false;
    
    
    [SerializeField] private float skill1CoolTime = 5;
    [SerializeField] private float skill2CoolTime = 20;
    
    [SerializeField] private int skill1Count = 5;
    [SerializeField] private int skill2Count = 2;

    [SerializeField] private TextMeshProUGUI text;

    private void Awake()
    {
        text.gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if(skill1Count > 0 && isSkill1CoolTime == false)
            {
                skill1Count--;
                skill1Image.fillAmount = 1;
                isSkill1CoolTime = true;
                PlayerControllor.Instance.Durability += 20;
                Debug.Log("skill1");
            }
            else if (skill1Count == 0 && (isSkill1CoolTime == false || isSkill1CoolTime == true))
            {
                text.gameObject.SetActive(true);
                text.text = "Insufficient skills.";
                StartCoroutine(Hide());
            }
            else if(isSkill1CoolTime == true)
            {
                text.gameObject.SetActive(true);
                text.text = "Skill cool time.";
                StartCoroutine(Hide());
            }
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (skill2Count > 0 && isSkill2CoolTime == false)
            {
                skill2Count--;
                skill2Image.fillAmount = 1;
                isSkill2CoolTime = true;
                Debug.Log("skill2");
            }
            else if (skill2Count == 0 && (isSkill2CoolTime == false || isSkill2CoolTime == true))
            {
                text.gameObject.SetActive(true);
                text.text = "Insufficient skills.";
                StartCoroutine(Hide());
            }
            else if(isSkill2CoolTime == true)
            {
                text.gameObject.SetActive(true);
                text.text = "Skill cool time.";
                StartCoroutine(Hide());
            }
        }

        if (isSkill1CoolTime == true)
        {
            skill1CoolTime -= Time.deltaTime;
            skill1Image.fillAmount = skill1CoolTime / 5;
            if (skill1CoolTime <= 0)
            {
                skill1CoolTime = 5;
                isSkill1CoolTime = false;
            }
        }
        
        if(isSkill2CoolTime == true)
        {
            skill2CoolTime -= Time.deltaTime;
            skill2Image.fillAmount = skill2CoolTime / 20;
            if (skill2CoolTime <= 0)
            {
                skill2CoolTime = 20;
                isSkill2CoolTime = false;
            }
        }
    }

    IEnumerator Hide()
    {
        yield return new WaitForSeconds(2f);
        text.gameObject.SetActive(false);
    }
}

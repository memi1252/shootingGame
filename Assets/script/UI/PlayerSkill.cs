using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSkill : MonoBehaviour
{
    [SerializeField] public Image skill1Image;
    [SerializeField] public Image skill2Image;
    
    [SerializeField] public bool isSkill1CoolTime = false;
    [SerializeField] public bool isSkill2CoolTime = false;
    
    
    [SerializeField] public float skill1CoolTime = 5;
    [SerializeField] public float skill2CoolTime = 20;
    
    [SerializeField] public int skill1Count = 5;
    [SerializeField] public int skill2Count = 2;

    [SerializeField] public TextMeshProUGUI text;

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
                GameManager.Instance.PlayerControllor.Durability += 20;
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
                if (GameManager.Instance.ammos != null)
                {
                    foreach (var ammo in GameManager.Instance.ammos)
                    {
                        Destroy(ammo);
                    }
                    GameManager.Instance.ammos.Clear();
                }
                if (GameManager.Instance.monsters != null)
                {
                    foreach (var Monster in GameManager.Instance.monsters)
                    {
                        Monster.GetComponent<MonsterControllor>().Hp -= 50;
                    }
                }
                if (GameManager.Instance.Boss != null)
                {
                    GameManager.Instance.Boss.GetComponent<BossControllor>().Hp -= 100;
                }
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

    public void HIDE()
    {
        gameObject.SetActive(false);
    }
}

using System;
using UnityEngine;

public class cheet : MonoBehaviour
{
    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.F1))
        {
            if (GameManager.Instance.monsters != null)
            {
                foreach (var monster in GameManager.Instance.monsters)
                {
                    Destroy(monster);
                }
                GameManager.Instance.monsters.Clear();
            }
            if(GameManager.Instance.Boss != null)
            {
                Destroy(GameManager.Instance.Boss);
                GameManager.Instance.Boss = null;
            }

            if (GameManager.Instance.rocks != null)
            {
                foreach (var rock in GameManager.Instance.rocks)
                {
                    Destroy(rock);
                }
                GameManager.Instance.rocks.Clear();
            }
        }else if (Input.GetKeyDown(KeyCode.F2))
        {
            GameManager.Instance.PlayerControllor.Damage = 45;
            GameManager.Instance.DamageUpCount = 5;
        }else if (Input.GetKeyDown(KeyCode.F3))
        {
            UIManager.Instance.PlayerSkill.skill1Count = 5;
            UIManager.Instance.PlayerSkill.skill2Count = 2;
            UIManager.Instance.PlayerSkill.skill1Image.fillAmount = 0;
            UIManager.Instance.PlayerSkill.skill2Image.fillAmount = 0;
            UIManager.Instance.PlayerSkill.isSkill1CoolTime = false;
            UIManager.Instance.PlayerSkill.isSkill2CoolTime = false;
            UIManager.Instance.PlayerSkill.skill1CoolTime = 5;
            UIManager.Instance.PlayerSkill.skill2CoolTime = 20;
        }else if (Input.GetKeyDown(KeyCode.F4))
        {
            GameManager.Instance.PlayerControllor.Durability = 100;
        }
        else if (Input.GetKeyDown(KeyCode.F5))
        {
            GameManager.Instance.PlayerControllor.fuel = 100;
        }else if(Input.GetKeyDown(KeyCode.F6))
        {
            GameManager.Instance.isBossDie1 = true;
        }
    }
}

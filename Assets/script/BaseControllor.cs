using UnityEngine;

public class BaseControllor : MonoBehaviour
{
    public void Attack(GameObject Ammo, int Damage)
    {
        var ammo = Instantiate(Ammo, transform.position, transform.rotation);
        GameManager.Instance.ammos.Add(ammo);
        ammo.GetComponent<Ammo>().damage = Damage;
        Debug.Log("Attack");
    }
    
}

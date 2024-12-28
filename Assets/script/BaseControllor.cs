using UnityEngine;

public class BaseControllor : MonoBehaviour
{
    public void Attack(GameObject Ammo, int Damage)
    {
        var ammo = Instantiate(Ammo, transform.position, transform.rotation);
        ammo.GetComponent<Ammo>().damage = Damage;
        Debug.Log("Attack");
    }
    
}

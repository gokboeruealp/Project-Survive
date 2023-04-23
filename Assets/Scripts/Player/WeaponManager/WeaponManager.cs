using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            weapons[0].weapon.Attack(weapons[0].gameObject, weapons[0].gameObject);
        }
    }
}
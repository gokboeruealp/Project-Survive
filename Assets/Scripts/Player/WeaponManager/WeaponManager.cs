using UnityEngine;
using System.Collections.Generic;

public class WeaponManager : MonoBehaviour
{
    [SerializeField] private List<Weapon> weapons;
    [SerializeField] private Transform player;
    [SerializeField] private Transform WeaponAttachPoint;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(weapons[0].weapon.AttackCoroutine(weapons[0].gameObject, player));
        }
    }
}
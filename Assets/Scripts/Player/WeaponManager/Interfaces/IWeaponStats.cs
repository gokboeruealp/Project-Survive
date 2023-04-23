using UnityEngine;

public interface IWeaponStats
{
    string weaponName { get; set; }
    int damage { get; set; }
    GameObject weaponPrefab { get; set; }
}

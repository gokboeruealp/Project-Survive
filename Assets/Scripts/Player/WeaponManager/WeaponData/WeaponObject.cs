using UnityEngine;

public abstract class WeaponObject : ScriptableObject
{
    [SerializeField] public WeaponStats weaponStats;
    public WeaponStats WeaponStats { get { return weaponStats; } }
    public abstract void Attack();
    public abstract void Attack(GameObject weapon);
    public abstract void Attack(GameObject weapon, GameObject player);
}

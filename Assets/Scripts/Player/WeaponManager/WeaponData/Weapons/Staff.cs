using UnityEngine;

[CreateAssetMenu(fileName = "New Staff", menuName = "Weapons/Staff", order = 1)]
[System.Serializable]
public class Staff : WeaponObject
{
    public override void Attack(GameObject Staff)
    {
        Debug.Log("Staff Attack");
    }

    public override void Attack() { }

    public override void Attack(GameObject weapon, GameObject player) { }
}
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponObject : ScriptableObject
{
    public string weaponName;
    public int damage;
    public float attackSpeed;
    public float attackRange;
    public float attackDelay;
    public float attackDuration;
    public float attackCooldown;
    public float attackCooldownDuration;
    public float attackCooldownDelay;

    public GameObject weaponPrefab;
    public GameObject attackEffect;

    public Sprite weaponSprite;
    public Sprite attackSprite;

    public AudioClip attackSound;
}

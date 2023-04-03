using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IWeapon
{
    public float Damage { get; set; }
    public float Range { get; set; }
    public float AttackSpeed { get; set; }
    public float AttackCooldown { get; set; }
    public float AttackDuration { get; set; }
    public EWeaponType WeaponType { get; set; }
    public string WeaponName { get; set; }
    public long WeaponId { get; set; }
    public int WeaponLevel { get; set; }
    public EWeaponRarity WeaponRarity { get; set; }
    public IStats DamageStat { get; set; }
    public IStats RangeStat { get; set; }
    public IStats AttackSpeedStat { get; set; }
    public IStats AttackCooldownStat { get; set; }
    public IStats AttackDurationStat { get; set; }

    public void MagicAttack()
    {
        throw new System.NotImplementedException();
    }

    public void MagicAttack(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void MagicAttack(float damage, float range)
    {
        throw new System.NotImplementedException();
    }

    public void MagicAttack(float damage, float range, float attackSpeed)
    {
        throw new System.NotImplementedException();
    }

    public void MagicAttack(float damage, float range, float attackSpeed, float attackCooldown)
    {
        throw new System.NotImplementedException();
    }

    public void MagicAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration)
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack()
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack(float damage, float range)
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack(float damage, float range, float attackSpeed)
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack(float damage, float range, float attackSpeed, float attackCooldown)
    {
        throw new System.NotImplementedException();
    }

    public void MeleeAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration)
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack()
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack(float damage)
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack(float damage, float range)
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack(float damage, float range, float attackSpeed)
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack(float damage, float range, float attackSpeed, float attackCooldown)
    {
        throw new System.NotImplementedException();
    }

    public void RangedAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration)
    {
        throw new System.NotImplementedException();
    }
}
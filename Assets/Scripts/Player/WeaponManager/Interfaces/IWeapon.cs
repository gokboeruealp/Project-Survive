public interface IWeapon
{
    //Close Combat
    void MeleeAttack();
    void MeleeAttack(float damage);
    void MeleeAttack(float damage, float range);
    void MeleeAttack(float damage, float range, float attackSpeed);
    void MeleeAttack(float damage, float range, float attackSpeed, float attackCooldown);
    void MeleeAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration);

    //Ranged Combat
    void RangedAttack();
    void RangedAttack(float damage);
    void RangedAttack(float damage, float range);
    void RangedAttack(float damage, float range, float attackSpeed);
    void RangedAttack(float damage, float range, float attackSpeed, float attackCooldown);
    void RangedAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration);

    //Magic Combat
    void MagicAttack();
    void MagicAttack(float damage);
    void MagicAttack(float damage, float range);
    void MagicAttack(float damage, float range, float attackSpeed);
    void MagicAttack(float damage, float range, float attackSpeed, float attackCooldown);
    void MagicAttack(float damage, float range, float attackSpeed, float attackCooldown, float attackDuration);

    //Weapon Stats
    float Damage { get; set; }
    float Range { get; set; }
    float AttackSpeed { get; set; }
    float AttackCooldown { get; set; }
    float AttackDuration { get; set; }

    //Weapon Type
    EWeaponType WeaponType { get; set; }

    //Weapon Name
    string WeaponName { get; set; }
    long WeaponId { get; set; }

    //Weapon Level
    int WeaponLevel { get; set; }

    //Weapon Rarity
    EWeaponRarity WeaponRarity { get; set; }

    //Weapon Stats
    IStats DamageStat { get; set; }
    IStats RangeStat { get; set; }
    IStats AttackSpeedStat { get; set; }
    IStats AttackCooldownStat { get; set; }
    IStats AttackDurationStat { get; set; }
}
namespace PlayerEnums
{
    public enum PlayerState
    {
        Idle,
        Walk,
        Hit,
        Die
    }

    public enum PlayerDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    public enum PlayerAnimation
    {
        Idle,
        Walk,
        Hit,
        Die
    }

    public enum EStatusEffectType
    {
        None,
        Poison,
        Burn,
        Freeze,
        Stun,
        Sleep,
        Confuse,
        Blind,
        Silence,
        Paralyze,
        Petrify,
        Curse,
        Charm,
        Berserk,
        Slow,
        Haste,
        Regen,
        Reflect,
        Absorb,
        Drain,
        Float,
        Gravity,
        Invincible
    }        

    public enum EBuffType
    {
        None,
        Strength,
        Dexterity,
        Agility,
        Vitality,
        Intelligence,
        Wisdom,
        Luck,
        Attack,
        Defense,
        MagicAttack,
        MagicDefense,
        Speed,
        Evasion,
        Accuracy,
        Critical,
        CriticalDamage
    }

    public enum EDebuffType
    {
        None,
        Strength,
        Dexterity,
        Agility,
        Vitality,
        Intelligence,
        Wisdom,
        Luck,
        Attack,
        Defense,
        MagicAttack,
        MagicDefense,
        Speed,
        Evasion,
        Accuracy,
        Critical,
        CriticalDamage
    }

    public enum EAttributeType
    {
        None,
        Strength,
        Dexterity,
        Agility,
        Vitality,
        Intelligence,
        Wisdom,
        Luck
    }

    public enum ESkillType
    {
        None,
        Attack,
        Defense,
        MagicAttack,
        MagicDefense,
        Speed,
        Evasion,
        Accuracy,
        Critical,
        CriticalDamage
    }

    public enum EStatType
    {
        None,
        Health,
        Experience,
        Level,
        Gold
    }

    public enum EEquipmentType
    {
        None,
        Weapon,
        Armor,
        Accessory
    }
}
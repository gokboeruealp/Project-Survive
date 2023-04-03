using UnityEngine;

public class Player : MonoBehaviour, IPlayer
{
    public IStatusEffects StatusEffects { get; set; }
    public IBuffs Buffs { get; set; }
    public IDebuffs Debuffs { get; set; }
    public IAttributes Attributes { get; set; }
    public ISkills Skills { get; set; }
    public IStats Health { get; set; }
    public IStats Experience { get; set; }
    public IStats Level { get; set; }
    public IStats Gold { get; set; }

    private void initialized()
    {
        StatusEffects = new StatusEffect();
        Buffs = new Buff();
        Debuffs = new Debuff();
        Attributes = new Attribute();
        Skills = new Skill();
        Health = new Stat();
        Experience = new Stat();
        Level = new Stat();
        Gold = new Stat();
    }

    private void Start()
    {
        initialized();
    }

    public void TakeDamage(float damage)
    {
        
    }

    public void GainExperience(float experience)
    {
        
    }

    public void GainGold(int gold)
    {
        
    }

    public void LevelUp()
    {
        
    }

    public void Die()
    {
        
    }
}

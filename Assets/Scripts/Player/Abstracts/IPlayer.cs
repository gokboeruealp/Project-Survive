public interface IPlayer
{
    // 
    // Summary:
    //     ///
    //     The player's current health.
    //     ///
    IStats Health { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current experience.
    //     ///
    IStats Experience { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current level.
    //     ///
    IStats Level { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current gold.
    //     ///
    IStats Gold { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current skills.
    //     ///
    ISkills Skills { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current buffs.
    //     ///
    IBuffs Buffs { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current debuffs.
    //     ///
    IDebuffs Debuffs { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current status effects.
    //     ///
    IStatusEffects StatusEffects { get; set; }
    //
    // Summary:
    //     ///
    //     The player's current attributes.
    //     ///
    IAttributes Attributes { get; set; }
}

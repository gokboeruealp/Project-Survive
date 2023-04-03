using System.Collections.Generic;

public interface IStatusEffects
{
    List<StatusEffect> GetStatusEffects();

    void AddStatusEffect(StatusEffect statusEffect);
    void RemoveStatusEffect(StatusEffect statusEffect);
    void RemoveAllStatusEffects();
}

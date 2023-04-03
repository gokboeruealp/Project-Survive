using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusEffect : MonoBehaviour, IStatusEffects
{
    public List<IStatusEffects> StatusEffects { get; set; }
    
    public void AddStatusEffect(StatusEffect statusEffect)
    {
        StatusEffects.Add(statusEffect);
    }

    public List<StatusEffect> GetStatusEffects()
    {
        return StatusEffects.Cast<StatusEffect>().ToList();
    }

    public void RemoveAllStatusEffects()
    {
        StatusEffects.Clear();
    }

    public void RemoveStatusEffect(StatusEffect statusEffect)
    {
        StatusEffects.Remove(statusEffect);
    }
}

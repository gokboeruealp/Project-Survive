using UnityEngine;

public class Stat : MonoBehaviour, IStats
{
    public float BaseValue { get; set; }
    public float Value { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }

    public void AddStat(IStats stat)
    {
        BaseValue += stat.BaseValue;
        Value += stat.Value;
        MinValue += stat.MinValue;
        MaxValue += stat.MaxValue;
    }

    public void AddStat(IStats stat, float duration)
    {
        
    }

    public void RemoveAllStats()
    {
        BaseValue = 0;
        Value = 0;
        MinValue = 0;
        MaxValue = 0;
    }

    public void RemoveAllStats(float duration)
    {
        
    }

    public void RemoveStat(IStats stat)
    {
        BaseValue -= stat.BaseValue;
        Value -= stat.Value;
        MinValue -= stat.MinValue;
        MaxValue -= stat.MaxValue;
    }

    public void RemoveStat(IStats stat, float duration)
    {
        
    }

    public void RemoveStat(string statId)
    {
        BaseValue = 0;
        Value = 0;
        MinValue = 0;
        MaxValue = 0;
    }

    public void RemoveStat(string statId, float duration)
    {
        
    }
}

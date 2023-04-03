using UnityEngine;

public class Buff : MonoBehaviour, IBuffs
{
    public float BaseValue { get; set; }
    public float Value { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public bool isInfinity { get; set; }

    public void AddBuff(IBuffs buff)
    {
        BaseValue += buff.BaseValue;
        Value += buff.Value;
        MinValue += buff.MinValue;
        MaxValue += buff.MaxValue;
    }

    public void AddBuff(IBuffs buff, float duration)
    {
        
    }

    public void RemoveAllBuffs()
    {
        BaseValue = 0;
        Value = 0;
        MinValue = 0;
        MaxValue = 0;
    }

    public void RemoveAllBuffs(float duration)
    {
        
    }

    public void RemoveBuff(IBuffs buff)
    {
        BaseValue -= buff.BaseValue;
        Value -= buff.Value;
        MinValue -= buff.MinValue;
        MaxValue -= buff.MaxValue;
    }

    public void RemoveBuff(IBuffs buff, float duration)
    {
        
    }

    public void RemoveBuff(string buffId)
    {
        BaseValue = 0;
        Value = 0;
        MinValue = 0;
        MaxValue = 0;
    }

    public void RemoveBuff(string buffId, float duration)
    {
        
    }
}

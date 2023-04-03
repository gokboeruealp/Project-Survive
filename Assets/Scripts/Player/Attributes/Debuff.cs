using UnityEngine;

public class Debuff : MonoBehaviour, IDebuffs
{
    public float BaseValue { get; set; }
    public float Value { get; set; }
    public float MinValue { get; set; }
    public float MaxValue { get; set; }
    public bool isInfinity { get; set; }

    public void AddDebuff(IDebuffs debuff)
    {
        throw new System.NotImplementedException();
    }

    public void AddDebuff(IDebuffs debuff, float duration)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAllDebuffs()
    {
        throw new System.NotImplementedException();
    }

    public void RemoveAllDebuffs(float duration)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveDebuff(IDebuffs debuff)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveDebuff(IDebuffs debuff, float duration)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveDebuff(string debuffId)
    {
        throw new System.NotImplementedException();
    }

    public void RemoveDebuff(string debuffId, float duration)
    {
        throw new System.NotImplementedException();
    }
}
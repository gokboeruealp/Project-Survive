public interface IDebuffs
{
    float BaseValue { get; set; }
    float Value { get; set; }
    float MinValue { get; set; }
    float MaxValue { get; set; }
    bool isInfinity { get; set; }

    void AddDebuff(IDebuffs debuff);
    void RemoveDebuff(IDebuffs debuff);
    void RemoveDebuff(string debuffId);
    void RemoveAllDebuffs();

    void AddDebuff(IDebuffs debuff, float duration);
    void RemoveDebuff(IDebuffs debuff, float duration);
    void RemoveDebuff(string debuffId, float duration);
    void RemoveAllDebuffs(float duration);
}

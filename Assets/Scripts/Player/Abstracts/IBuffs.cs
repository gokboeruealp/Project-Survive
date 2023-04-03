public interface IBuffs
{
    float BaseValue { get; set; }
    float Value { get; set; }
    float MinValue { get; set; }
    float MaxValue { get; set; }
    bool isInfinity { get; set; }

    void AddBuff(IBuffs buff);
    void RemoveBuff(IBuffs buff);
    void RemoveBuff(string buffId);
    void RemoveAllBuffs();

    void AddBuff(IBuffs buff, float duration);
    void RemoveBuff(IBuffs buff, float duration);
    void RemoveBuff(string buffId, float duration);
    void RemoveAllBuffs(float duration);
}

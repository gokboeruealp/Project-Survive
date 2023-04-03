public interface IStats
{
    float BaseValue { get; set; }
    float Value { get; set; }
    float MinValue { get; set; }
    float MaxValue { get; set; }


    void AddStat(IStats stat);
    void RemoveStat(IStats stat);
    void RemoveStat(string statId);
    void RemoveAllStats();

    void AddStat(IStats stat, float duration);
    void RemoveStat(IStats stat, float duration);
    void RemoveStat(string statId, float duration);
    void RemoveAllStats(float duration);
}

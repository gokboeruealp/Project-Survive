public interface ISkills
{
    void AddSkill(ISkills skill);
    void RemoveSkill(ISkills skill);
    void RemoveSkill(string skillId);
    void RemoveAllSkills();

    void AddSkill(ISkills skill, float duration);
    void RemoveSkill(ISkills skill, float duration);
    void RemoveSkill(string skillId, float duration);
    void RemoveAllSkills(float duration);
}
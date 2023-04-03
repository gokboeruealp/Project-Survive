public interface IAttributes
{
    void AddAttribute(IAttributes attribute);
    void RemoveAttribute(IAttributes attribute);
    void RemoveAttribute(string attributeId);
    void RemoveAllAttributes();

    void AddAttribute(IAttributes attribute, float duration);
    void RemoveAttribute(IAttributes attribute, float duration);
    void RemoveAttribute(string attributeId, float duration);
    void RemoveAllAttributes(float duration);
}

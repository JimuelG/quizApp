namespace Core.Entities;

public class Subject : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public ICollection<Question> Questions { get; set; } = new List<Question>();
}

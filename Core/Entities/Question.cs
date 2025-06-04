namespace Core.Entities;

public class Question : BaseEntity
{
    public string QuestionText { get; set; } = string.Empty;
    public string[]? Choices { get; set; }
    public string CorrectAnswer { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    
    public int SubjectId { get; set; }
    public required Subject Subject { get; set; }

    public QuestionCategory Category { get; set; }
}

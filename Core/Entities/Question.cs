namespace Core.Entities;

public class Question : BaseEntity
{
    public required string QuestionText { get; set; }
    public string[]? Choices { get; set; }
    public required string CorrectAnswer { get; set; }
    public required string Type { get; set; }
    public required string Subject { get; set; }
}

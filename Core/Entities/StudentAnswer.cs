namespace Core.Entities;

public class StudentAnswer : BaseEntity
{
    public string Answer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }

    public int QuestionId { get; set; }
    public Question Question { get; set; } = null!;

    public string StudentId { get; set; } = string.Empty;
    
}

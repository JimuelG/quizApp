namespace Core.Entities;

public class StudentAnswer : BaseEntity
{
    public int QuestionId { get; set; }
    public string AnswerGiven { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public int StudentQuizId { get; set; }
    public StudentQuiz StudentQuiz { get; set; } = null!;
    
}

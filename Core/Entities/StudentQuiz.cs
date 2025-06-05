namespace Core.Entities;

public class StudentQuiz : BaseEntity
{
    public string StudentId { get; set; } = string.Empty;
    public int TotalQuestions { get; set; }
    public int CorrectAnswers { get; set; }
    public double ScorePercentage { get; set; }

    public DateTime DateTaken { get; set; } = DateTime.UtcNow;

    public ICollection<StudentAnswer> StudentAnswers { get; set; } = new List<StudentAnswer>();
}

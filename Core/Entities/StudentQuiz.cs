namespace Core.Entities;

public class StudentQuiz : BaseEntity
{
    public string StudentId { get; set; } = string.Empty;

    public DateTime TakenAt { get; set; } = DateTime.UtcNow;
    public int Score { get; set; }

    public ICollection<StudentAnswer> Answers { get; set; } = new List<StudentAnswer>();
}

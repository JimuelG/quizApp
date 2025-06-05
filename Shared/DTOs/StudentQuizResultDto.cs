namespace Shared.DTOs;

public class StudentQuizResultDto
{
    public int QuizId { get; set; }
    public string studentId { get; set; } = string.Empty;
    public int TotalQuestions { get; set; }
    public int CorrectAnswer { get; set; }
    public double ScorePercentage { get; set; }
}

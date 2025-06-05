namespace Shared.DTOs;

public class QuizSubmissionDto
{
    public int SubjectId { get; set; }
    public List<SubmittedAnswerDto> Answers { get; set; } = new();
}

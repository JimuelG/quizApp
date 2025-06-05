namespace Shared.DTOs;

public class SubmittedAnswerDto
{
    public int QuestionId { get; set; }
    public string SelectedAnswer { get; set; } = string.Empty;
}

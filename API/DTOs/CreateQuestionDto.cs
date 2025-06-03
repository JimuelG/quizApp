using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateQuestionDto
{
    [Required]
    public string QuestionText { get; set; } = string.Empty;
    public string[]? Choices { get; set; }
    [Required]
    public string CorrectAnswer { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public string Subject { get; set; } = string.Empty;
}

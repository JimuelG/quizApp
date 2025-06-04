using System.ComponentModel.DataAnnotations;

namespace API.DTOs;

public class CreateQuestionDto
{
    [Required]
    public string QuestionText { get; set; } = string.Empty;
    [Required]
    public List<string> Choices { get; set; } = new();
    [Required]
    public string CorrectAnswer { get; set; } = string.Empty;
    [Required]
    public string Type { get; set; } = string.Empty;
    [Required]
    public int SubjectId { get; set; }
    [Required]
    public string Category { get; set; } = string.Empty;
}

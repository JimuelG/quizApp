using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Interfaces;

namespace API.Controllers;

[Authorize(Roles = "Student")]
public class StudentController(IQuizEvaluationService quizEvaluationService) : BaseApiController
{
    [HttpPost("submit")]
    public async Task<ActionResult> SubmitQuiz([FromBody] QuizSubmissionDto submissionDto)
    {
        string studentId = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value!;

        if (string.IsNullOrEmpty(studentId))
        {
            return Unauthorized("Student ID not found in token");
        }

        var studentQuiz = await quizEvaluationService.EvaluateAndSaveAsync(submissionDto, studentId);

        return Ok(new
        {
            Score = studentQuiz.ScorePercentage,
            TotalQuestions = studentQuiz.TotalQuestions,
            QuizId = studentQuiz.QuizId
        });
    }

    [HttpGet("test")]
    public IActionResult TestRoute() => Ok("StudentController is active");


}

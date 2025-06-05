using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shared.DTOs;

namespace API.Controllers;

public class QuestionsController(IGenericRepository<Question> repo,
    AppDbContext context) : BaseApiController
{

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Question>>> GetQuestions()
    {
        return Ok(await repo.ListAllAsync());
    }

    [HttpGet("id")]
    public async Task<ActionResult<Question>> GetQuestion(int id)
    {
        var question = await repo.GetByIdAsync(id);
        return question is null ? NotFound() : Ok(question);
    }

    [HttpPost]
    public async Task<ActionResult> CreateQuestion([FromBody] CreateQuestionDto dto)
    {
        if (!Enum.TryParse<QuestionCategory>(dto.Category, true, out var categoryEnum))
            return BadRequest("Invalid category. Use 'Prelim' or 'Midterm'");

        var subjectExists = await context.Subjects.AnyAsync(s => s.Id == dto.SubjectId);
        if (!subjectExists) return NotFound("Subject not found");

        var question = new Question
        {
            QuestionText = dto.QuestionText,
            Choices = dto.Choices.ToArray(),
            CorrectAnswer = dto.CorrectAnswer,
            Type = dto.Type,
            SubjectId = dto.SubjectId,
            Category = categoryEnum
        };

        context.Questions.Add(question);
        await context.SaveChangesAsync();

        return Ok(question);
    }
}

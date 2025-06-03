using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class QuestionsController(IGenericRepository<Question> repo) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Question>>> GetQuestionsAsync()
    {
        return Ok(await repo.ListAllAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult> GetQuestionById(int id)
    {
        var question = await repo.GetByIdAsync(id);

        return Ok(question);
    }

    [HttpPost]
    public async Task<ActionResult> CreateQuestion(CreateQuestionDto questionDto)
    {
        var question = new Question
        {
            QuestionText = questionDto.QuestionText,
            Choices = questionDto.Choices,
            CorrectAnswer = questionDto.CorrectAnswer,
            Type = questionDto.Type,
            Subject = questionDto.Subject
        };

        repo.Add(question);
        await repo.SaveChangesAsync();

        return Ok(new
        {
            question.Id,
            question.QuestionText,
            question.Choices,
            question.CorrectAnswer,
            question.Type,
            question.Subject
        });
    }
}

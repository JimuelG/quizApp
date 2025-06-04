using API.DTOs;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class QuestionsController(IGenericRepository<Question> repo) : BaseApiController
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
    public async Task<ActionResult> CreateQuestion(Question question)
    {
        repo.Add(question);
        await repo.SaveChangesAsync();
        return Ok(question);
    }
}

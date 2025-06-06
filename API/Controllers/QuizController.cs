using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class QuizController(IGenericRepository<Question> repo) : BaseApiController
{
    [HttpGet("{subjectId}/quiz/{category}")]
    public async Task<ActionResult<IEnumerable<Question>>> GetQuiz(int subjectId,
        QuestionCategory category)
    {
        var questions = await repo.ListAllAsync();
        var filtered = questions
            .Where(q => q.SubjectId == subjectId && q.Category == category)
            .OrderBy(_ => Guid.NewGuid())
            .Take(10)
            .ToList();

        return Ok(filtered);
    }

    [HttpGet("{subjectId}/exam")]
    public async Task<ActionResult<IEnumerable<Question>>> GetExam(int subjectId)
    {
        var questions = await repo.ListAllAsync();
        var filtered = questions
            .Where(q => q.SubjectId == subjectId &&
                        (q.Category == QuestionCategory.Prelim || q.Category == QuestionCategory.Midterm))
            .OrderBy(_ => Guid.NewGuid())
            .Take(30)
            .ToList();

        return Ok(filtered);
    }


}

using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

// [Authorize(Roles = "Admin")]
public class SubjectController(IGenericRepository<Subject> repo,
    AppDbContext context) : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Subject>>> GetSubjects()
    {
        var subject = await repo.ListAllAsync();
        return Ok(subject);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Subject>> GetSubjectById(int id)
    {
        var subject = await repo.GetByIdAsync(id);
        if (subject == null) return NotFound();
        return Ok(subject);
    }

    [HttpPost]
    public async Task<ActionResult> CreateSubject([FromBody] Subject subject)
    {
        context.Subjects.Add(subject);
        await context.SaveChangesAsync();
        return Ok(subject);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteSubject(int id)
    {
        var subject = await repo.GetByIdAsync(id);
        if (subject == null) return NotFound();

        repo.Remove(subject);
        return NoContent();
    }
}

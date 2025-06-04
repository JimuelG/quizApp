using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class SubjectController(IGenericRepository<Subject> repo) : BaseApiController
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
    public async Task<ActionResult> CreateSubject(Subject subject)
    {
        repo.Add(subject);
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

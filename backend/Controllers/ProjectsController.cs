
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly ProjectService _service;

    public ProjectsController(ProjectService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<ProjectResponseDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ProjectResponseDto>> GetById(int id)
    {
        var project = await _service.GetByIdAsync(id);

        if (project == null)
            return NotFound();

        return Ok(project);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponseDto>> Create(
        ProjectCreateDto dto)
    {
        var project = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = project.Id },
            project
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id, ProjectUpdateDto dto)
    {
        var updated = await _service.UpdateAsync(id, dto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}

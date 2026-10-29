
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTOs;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers;

[ApiController]
[Route("api/blogposts")]
public class BlogpostsController : ControllerBase
{
    private readonly BlogpostService _service;

    public BlogpostsController(BlogpostService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<List<BlogpostResponseDto>>> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogpostResponseDto>> GetById(int id)
    {
        var blogpost = await _service.GetByIdAsync(id);

        if (blogpost == null)
            return NotFound();

        return Ok(blogpost);
    }

    [HttpPost]
    public async Task<ActionResult<BlogpostResponseDto>> Create(
        BlogpostCreateDto dto)
    {
        var blogpost = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = blogpost.Id },
            blogpost
        );
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id, BlogpostUpdateDto dto)
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

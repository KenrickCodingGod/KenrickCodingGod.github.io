
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class BlogpostService
{
    private readonly PortfolioDbContext _context;

    public BlogpostService(PortfolioDbContext context)
    {
        _context = context;
    }

    private static BlogpostResponseDto ToDto(Blogpost blogpost)
    {
        return new BlogpostResponseDto(
            blogpost.Id,
            blogpost.Titel,
            blogpost.Inhoud,
            blogpost.Publicatiedatum
        );
    }

    public async Task<List<BlogpostResponseDto>> GetAllAsync()
    {
        var blogposts = await _context.Blogposts
            .AsNoTracking()
            .ToListAsync();

        return blogposts.Select(ToDto).ToList();
    }

    public async Task<BlogpostResponseDto?> GetByIdAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        return blogpost == null ? null : ToDto(blogpost);
    }

    public async Task<BlogpostResponseDto> CreateAsync(
        BlogpostCreateDto dto)
    {
        var blogpost = new Blogpost
        {
            Titel = dto.Titel,
            Inhoud = dto.Inhoud,
            Publicatiedatum = dto.Publicatiedatum
        };

        _context.Blogposts.Add(blogpost);
        await _context.SaveChangesAsync();

        return ToDto(blogpost);
    }

    public async Task<bool> UpdateAsync(
        int id, BlogpostUpdateDto dto)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost == null)
            return false;

        blogpost.Titel = dto.Titel;
        blogpost.Inhoud = dto.Inhoud;
        blogpost.Publicatiedatum = dto.Publicatiedatum;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var blogpost = await _context.Blogposts.FindAsync(id);

        if (blogpost == null)
            return false;

        _context.Blogposts.Remove(blogpost);
        await _context.SaveChangesAsync();

        return true;
    }
}

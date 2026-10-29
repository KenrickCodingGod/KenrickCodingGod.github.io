
using Microsoft.EntityFrameworkCore;
using PortfolioApi.Data;
using PortfolioApi.DTOs;
using PortfolioApi.Models;

namespace PortfolioApi.Services;

public class ProjectService
{
    private readonly PortfolioDbContext _context;

    public ProjectService(PortfolioDbContext context)
    {
        _context = context;
    }

    private static ProjectResponseDto ToDto(Project project)
    {
        return new ProjectResponseDto(
            project.Id,
            project.Titel,
            project.Beschrijving,
            project.Categorie,
            project.GitHubUrl,
            project.Datum
        );
    }

    public async Task<List<ProjectResponseDto>> GetAllAsync()
    {
        var projects = await _context.Projects
            .AsNoTracking()
            .ToListAsync();

        return projects.Select(ToDto).ToList();
    }

    public async Task<ProjectResponseDto?> GetByIdAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        return project == null ? null : ToDto(project);
    }

    public async Task<ProjectResponseDto> CreateAsync(
        ProjectCreateDto dto)
    {
        var project = new Project
        {
            Titel = dto.Titel,
            Beschrijving = dto.Beschrijving,
            Categorie = dto.Categorie,
            GitHubUrl = dto.GitHubUrl,
            Datum = dto.Datum
        };

        _context.Projects.Add(project);
        await _context.SaveChangesAsync();

        return ToDto(project);
    }

    public async Task<bool> UpdateAsync(
        int id, ProjectUpdateDto dto)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
            return false;

        project.Titel = dto.Titel;
        project.Beschrijving = dto.Beschrijving;
        project.Categorie = dto.Categorie;
        project.GitHubUrl = dto.GitHubUrl;
        project.Datum = dto.Datum;

        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var project = await _context.Projects.FindAsync(id);

        if (project == null)
            return false;

        _context.Projects.Remove(project);
        await _context.SaveChangesAsync();

        return true;
    }
}

using Microsoft.EntityFrameworkCore;
using ProjectTracker.Data;
using ProjectTracker.DTO;
using ProjectTracker.DTO.Project;
using ProjectTracker.Models;
using System.Linq;
using System.Linq.Expressions;


namespace ProjectTracker.Services
{
    public class ProjectService:IProjectService
    {
        private readonly AppDbContext _context;

        public ProjectService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<ProjectResponseDto>> GetAllAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            var response = projects.Select(p => new ProjectResponseDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                CreatedAt = p.CreatedAt
            }).ToList();
            return response;
        }
        public async Task<ProjectResponseDto?> GetByIdAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return null;

            // Ручной маппинг: Project -> ProjectResponseDto
            var response = new ProjectResponseDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
            return response;
        }
        public async Task<ProjectResponseDto> CreateAsync(ProjectCreateDto dto)
        {
            var project = new Project//создаём модель из DTO
            {
                Name = dto.Name,
                Description = dto.Description ?? string.Empty,
                CreatedAt = DateTime.UtcNow
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
            //маппим обратно в DTO
            var response = new ProjectResponseDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt
            };
            return response;
        }
        public async Task<bool> UpdateAsync(int id, ProjectUpdateDto dto)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null)
                return false;
            project.Name = dto.Name;
            project.Description = dto.Description ?? string.Empty;
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
}

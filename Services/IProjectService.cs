using ProjectTracker.Data;
using ProjectTracker.DTO;
using ProjectTracker.DTO.Project;

namespace ProjectTracker.Services
{
    public interface IProjectService
    {
        Task<List<ProjectResponseDto>> GetAllAsync();
        Task<ProjectResponseDto?> GetByIdAsync(int id);
        Task<ProjectResponseDto> CreateAsync(ProjectCreateDto dto);
        Task<bool> UpdateAsync(int id, ProjectUpdateDto dto);
        Task<bool> DeleteAsync(int id);
    }
}

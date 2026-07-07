using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.DTO.Task
{
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        public int ProjectId { get; set; }
    }
}

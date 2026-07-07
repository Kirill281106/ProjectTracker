using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.DTO.Task
{
    public class TaskItemUpdateDto
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; }
        [Required]
        public string Status { get; set; }
    }
}

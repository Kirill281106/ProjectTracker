using System.ComponentModel.DataAnnotations;

namespace ProjectTracker.DTO.Project
{
    public class ProjectUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        public string Description {  get; set; }
    }
}

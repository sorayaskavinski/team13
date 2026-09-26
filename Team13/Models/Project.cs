using System.ComponentModel.DataAnnotations;

namespace Team13.Models;

public class Project
{
    public int ProjectId { get; set; }

    [Required]
    [StringLength(200)]
    public string Name { get; set; } = string.Empty;

    public string? Description { get; set; }

    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}
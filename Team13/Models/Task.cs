using System.ComponentModel.DataAnnotations;

namespace Team13.Models;

public class Task
{
    public int TaskId { get; set; }

    [Required]
    [StringLength(200)]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public string Priority { get; set; } = "Medium";

    public string Status { get; set; } = "Not Started";

    public int? AssignedTo { get; set; }

    public User? AssignedUser { get; set; }

    [Range(1, int.MaxValue)]
    public int ProjectId { get; set; }

    public Project Project { get; set; } = null!;
}
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

    public int ProjectId { get; set; }
}
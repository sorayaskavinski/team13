using System.ComponentModel.DataAnnotations;

namespace Team13.Models;

public class User
{
    public int UserId { get; set; }

    [Required]
    [StringLength(100)]
    public string UserName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    [StringLength(255)]
    public string Email { get; set; } = string.Empty;

    public ICollection<Task> AssignedTasks { get; set; } = new List<Task>();
}
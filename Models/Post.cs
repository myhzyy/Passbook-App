using System.ComponentModel.DataAnnotations;

namespace Pawbook.Models;

public class Post
{
    public int Id { get; set; }

    public int UserId { get; set; }

    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Caption { get; set; } = string.Empty;

    public int Likes { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public User? User { get; set; }
}
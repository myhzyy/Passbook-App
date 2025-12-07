using System.ComponentModel.DataAnnotations;

namespace Pawbook.Models;

public class User
{
    public int Id { get; set; }

    [MaxLength(20)]
    public string Username { get; set; } = string.Empty;

    public int Age { get; set; }

    [MaxLength(30)]
    public string Breed { get; set; } = string.Empty;

    [MaxLength(10)]
    public string Gender { get; set; } = string.Empty;

    public ICollection<Post> Posts { get; set; } = new List<Post>();
}
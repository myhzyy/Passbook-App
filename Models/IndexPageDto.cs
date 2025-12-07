namespace Pawbook.Models;

public class IndexPageDto
{
    
    public int Id { get; set; }
    public int UserId { get; set; }
    
    public string UserName { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Caption { get; set; } = string.Empty;
    
    public int Likes {get; set;}
    
    public DateTime CreatedAt { get; set; }
    public string CreatedAtFormatted => CreatedAt.ToString("dd MMM yyyy");

}
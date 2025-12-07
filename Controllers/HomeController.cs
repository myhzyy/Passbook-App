using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pawbook.Data;
using Pawbook.Models;

namespace Pawbook.Controllers;

public class HomeController : Controller
{
    private readonly PawbookDbContext _context;

    public HomeController(PawbookDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        var posts = await _context.Posts
            .Include(p => p.User)
            .Select(p => new IndexPageDto
            {
                Id = p.Id,
                UserId =  p.UserId,
                UserName = p.User.Username,
                ImageUrl = p.ImageUrl,
                Caption = p.Caption,
                Likes = p.Likes,
                CreatedAt = p.CreatedAt,
            })
            .ToListAsync();

        return View(posts);
    }
    
    [HttpPost]
    public async Task<IActionResult> LikePost(int id)
    {
        var post = await _context.Posts.FirstOrDefaultAsync(p => p.Id == id);

        post.Likes++;
        
        await _context.SaveChangesAsync();
        
        return Json(post);
    }
}
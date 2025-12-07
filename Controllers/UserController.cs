using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pawbook.Data;
using System.Text.Json;
using Pawbook.Models;

namespace Pawbook.Controllers;

public class UserController : Controller
{

    private readonly PawbookDbContext _context;
    private readonly ILogger<UserController> _logger;
    
    public UserController(PawbookDbContext context, ILogger<UserController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    
    [HttpGet]
    public async Task<IActionResult> Index(int id)
    {

        var profile = await _context.Users
            .Include(u => u.Posts)
            .FirstOrDefaultAsync(u => u.Id == id);
        
        return View(profile);
    }

    [HttpGet]
    public async Task<IActionResult> PostedImage(int id, int postId)
    {

        var user  = await _context.Users.Include(u => u.Posts).FirstOrDefaultAsync(u => u.Id == id);

        if (user == null)
        {
            return NotFound();
        }
        
        var post = user.Posts.FirstOrDefault(p => p.Id == postId);

        if (post == null)
        {
            return NotFound();
        }

        var dto = new PostedImageDto
        {
            Caption = post.Caption,
            ImageUrl = post.ImageUrl,
            UserName = user.Username
        };
        
        
        return View(dto);
    }
}
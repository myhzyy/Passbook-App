using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pawbook.Data;
using Pawbook.Models;

namespace Pawbook.Controllers;

public class UploadController : Controller
{
    private readonly PawbookDbContext _context;
    private readonly ILogger<UploadController> _logger;


    public UploadController(PawbookDbContext context, ILogger<UploadController> logger)
    {
        _context = context;
        _logger = logger;
    }
    
    
    public async Task<IActionResult> Index()
    {

        var users = await _context.Users.ToListAsync();
        
        return View(users);
    }

    [HttpPost]
    public async Task<IActionResult> UploadImage(int userId, string imageUrl, string caption)
    {

        
        var post = new Post
        {
        
            UserId = userId,
            ImageUrl = imageUrl,
            Caption = caption
        };
        
        _context.Posts.Add(post);
        
        await _context.SaveChangesAsync();
        
        
        return RedirectToAction("Index", "Upload");
        
    }
    
}
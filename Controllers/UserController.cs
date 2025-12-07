using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pawbook.Data;
using System.Text.Json;

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
}
using Microsoft.AspNetCore.Mvc;
using Pawbook.Data;
using Pawbook.Models;

namespace Pawbook.Controllers;

public class SignUp : Controller
{

    private readonly PawbookDbContext _context;


    public SignUp(PawbookDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Register(string userName, int age, string breed, string gender)
    {

        var newUser = new User
        {

        Username = userName,
        Age = age,
        Breed = breed,
        Gender = gender
        
        };

        _context.Users.Add(newUser);
        
        
        _context.SaveChanges();

        return RedirectToAction("Index");


    }
    
    
}
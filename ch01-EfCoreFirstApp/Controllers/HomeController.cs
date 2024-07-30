using EfCoreFirstApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreFirstApp.Controllers;

public class HomeController : Controller
{
    private DataContext _context;

    public HomeController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index() => View();

    public IActionResult Respond() => View();

    [HttpPost]
    public IActionResult Respond(GuestResponse response)
    {
        _context.Responses.Add(response);

        _context.SaveChanges();

        return RedirectToAction(nameof(Thanks), new { Name = response.Name, WillAttend = response.WillAttend });
    }

    public IActionResult Thanks(GuestResponse response) => View(response);

    public IActionResult ListResponses() =>
        View(_context.Responses.OrderByDescending(r => r.WillAttend));
}
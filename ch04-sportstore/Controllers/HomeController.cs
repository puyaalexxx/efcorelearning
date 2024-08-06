using ch04_Sportstore.Models;
using Microsoft.AspNetCore.Mvc;

namespace ch04_Sportstore.Controllers;

public class HomeController : Controller
{
    private readonly IRepository _repo;

    public HomeController(IRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Index()
    {
        return View(_repo.Products);
    }

    public IActionResult AddProduct(Product product)
    {
        _repo.AddProduct(product);
        
        return RedirectToAction(nameof(Index));
    }

    public IActionResult UpdateProduct(int key)
    {
        return View(_repo.GetProduct(key));
    }

    [HttpPost]
    public IActionResult UpdateProduct(Product product)
    {
        _repo.UpdateProduct(product);

        return RedirectToAction(nameof(Index));
    }

    public IActionResult UpdateAll()
    {
        ViewBag.UpdateAll = true;

        return View(nameof(Index), _repo.Products);
    }
    
    [HttpPost]
    public IActionResult UpdateAll(Product[] products)
    {
        _repo.UpdateAll(products);

        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    public IActionResult Delete(Product product)
    {
        _repo.Delete(product);

        return RedirectToAction(nameof(Index));
    }
}
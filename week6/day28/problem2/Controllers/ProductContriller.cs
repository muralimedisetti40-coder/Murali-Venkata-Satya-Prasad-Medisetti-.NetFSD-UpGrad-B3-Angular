using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NewMvcApp.Models;

namespace NewMvcApp.Controllers;

public class ProductController : Controller
{
    
    List<Product> products = new List<Product>()
            {
                
            new Product{ Id = 1, Name = "Laptop", Category = "Electronics", Price = 50000 },
            new Product{ Id = 2, Name = "Mobile", Category = "Electronics", Price = 20000 },
            new Product{ Id = 3, Name = "Shoes", Category = "Fashion", Price = 3000 }
        };
    public IActionResult Index()
    {
            return View(products);
    }
    public IActionResult Details(int Id)
    {
        var product=products.Find(p=>p.Id==Id);
        return View(product);
    }
}

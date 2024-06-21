using KhumaloCrafting___.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using KhumaloCrafting___.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using KhumaloCrafting___.Data;

namespace KhumaloCrafting___.Controllers
{
    public class HomeController : Controller
    {
        private readonly KhumaloCraft_Context _context;
        private readonly ProductRepository _productRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, KhumaloCraft_Context context, ProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
            _logger = logger;
        }


        public IActionResult Index()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public async Task<IActionResult> MyWork()
        {
            var Products = await _context.Product.ToListAsync();
            return View(Products);
        }

        // Other action methods...
        public IActionResult SeedProducts()
        {
            _productRepository.InsertProducts();
            return RedirectToAction("MyWork"); // Redirect to MyWork action after seeding products
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Search(string type)
        {
            var products = _context.Product.AsQueryable();

            if (!string.IsNullOrEmpty(type))
            {
                products = products.Where(p => p.Name.Contains(type));
            }

        
            return View("Search", await products.ToListAsync());
        }


    }


}

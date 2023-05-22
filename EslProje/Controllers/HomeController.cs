using EslProje.DAL;
using EslProje.Models;
using EslProje.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EslProje.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM HomeVM = new HomeVM()
            {
                Categories = await _context.Categories.ToListAsync(),
                Products = await _context.Products
                .OrderByDescending(i => i.Id)

                .ToListAsync()
            };
            return View(HomeVM);
       

           
        }
      


    }
}